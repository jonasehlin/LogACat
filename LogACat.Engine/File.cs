using System;

namespace LogACat.Engine
{
	public class File
	{
		public Guid Id { get; set; }
		public Guid DirectoryId { get; set; }
		public string Name { get; set; }
		public ulong Size { get; set; }
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

		public static File Create(Directory directory, string name, ulong size, byte[] checksum, IDateTimeProvider dateTimeProvider)
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

		public override string ToString()
		{
			return $"Name = {Name}, Size = {Size}";
		}
	}
}
