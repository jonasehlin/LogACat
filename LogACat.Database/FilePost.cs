using System;

namespace LogACat.Database
{
	public class FilePost
    {
		public Guid Id { get; set; }
		public Guid? ParentId { get; set; }
		public FilePostType Type { get; set; }
		public string Name { get; set; }
		public ulong? Size { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
		public string Checksum { get; set; }
	}

	public enum FilePostType : byte
	{
		None = 0,
		File = 1,
		Directory = 2
	}
}
