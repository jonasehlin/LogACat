using System.Collections.Generic;

namespace LogACat.Engine
{
	public class DirectoryItem : Item
	{
		public readonly List<DirectoryItem> Directories = new List<DirectoryItem>();
		public readonly List<FileItem> Files = new List<FileItem>();

		public override ulong Size
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
