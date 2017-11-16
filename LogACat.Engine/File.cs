using System;
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

		public static File Create(Directory directory, string name, long size, DateTime created, DateTime modified, byte[] checksum)
		{
			return new File()
			{
				Id = Guid.NewGuid(),
				Directory = directory,
				Name = name,
				Size = size,
				Created = created,
				Modified = modified,
				Checksum = checksum
			};
		}

		public static File Create(Directory directory, string name, long size, byte[] checksum, IDateTimeProvider dateTimeProvider)
		{
			var now = dateTimeProvider.UtcNow;
			return Create(directory, name, size, now, now, checksum);
		}

		public static File Create(FileInfo fileInfo, Directory parentDirectory)
		{
			if (!fileInfo.Exists)
				throw new FileNotFoundException();

			return Create(parentDirectory, fileInfo.Name, fileInfo.Length,
				fileInfo.CreationTimeUtc, fileInfo.LastWriteTimeUtc, fileInfo.OpenRead().GetMD5Checksum());
		}

		public override string ToString()
		{
			return $"Name = {Name}, Size = {Size}";
		}
	}
}
