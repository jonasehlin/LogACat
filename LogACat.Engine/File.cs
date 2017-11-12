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
		public string Checksum { get; set; }
	}
}
