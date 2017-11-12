using System.Collections.Generic;

namespace LogACat.Engine
{
	public class Directory
	{
		public readonly List<Directory> Directories = new List<Directory>();
		public readonly List<File> Files = new List<File>();

		public ulong Size
		{
			get
			{
				return GetDirectorySize() + GetFileSize();
			}
		}

		private ulong GetFileSize()
		{
			ulong size = 0;
			foreach (var file in Files)
				size += file.Size;
			return size;
		}

		private ulong GetDirectorySize()
		{
			ulong size = 0;
			foreach (var dir in Directories)
				size += dir.Size;
			return size;
		}
	}
}
