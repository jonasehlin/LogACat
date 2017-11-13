using System;
using System.Diagnostics;
using System.IO;

namespace LogACat.Engine
{
	public class File
	{
		public Guid Id { get; set; }
		public Guid DirectoryId { get; set; }
		public string Name { get; set; }
		public long Size { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
		public byte[] Checksum { get; set; }

		private Directory _directory;

		public Directory Directory
		{
			get { return _directory; }
			set
			{
				if (value.Id == Id)
					throw new ArgumentException();

				_directory = value;
				DirectoryId = value.Id;
			}
		}

		public static File Create(Directory directory, string name, long size, byte[] checksum, IDateTimeProvider dateTimeProvider)
		{
			var now = dateTimeProvider.UtcNow;
			return new File()
			{
				Id = Guid.NewGuid(),
				Directory = directory,
				Name = name,
				Size = size,
				Created = now,
				Modified = now,
				Checksum = checksum
			};
		}

		public static File Create(FileInfo fileInfo, Directory parentDirectory)
		{
			if (!fileInfo.Exists)
				throw new FileNotFoundException();

			return new File()
			{
				Id = Guid.NewGuid(),
				Directory = parentDirectory,
				Name = fileInfo.Name,
				Size = fileInfo.Length,
				Created = fileInfo.CreationTimeUtc,
				Modified = fileInfo.LastWriteTimeUtc,
				Checksum = fileInfo.OpenRead().GetMD5Checksum()
			};
		}

		public override string ToString()
		{
			return $"Name = {Name}, Size = {Size}";
		}
	}
}
