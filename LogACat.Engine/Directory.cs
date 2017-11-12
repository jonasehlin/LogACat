using System;
using System.Collections.Generic;

namespace LogACat.Engine
{
	public class Directory
	{
		public Guid Id { get; set; }
		public Guid? ParentId { get; set; }
		public string Name { get; set; }
		public DateTime Created { get; set; }

		public readonly List<Directory> Directories = new List<Directory>();
		public readonly List<File> Files = new List<File>();

		Directory _parent;

		public Directory Parent
		{
			get { return _parent; }
			set
			{
				if (value == null)
				{
					_parent = null;
					ParentId = null;
				}
				else
				{
					if (ReferenceEquals(value, this) || value.Id == Id)
						throw new ArgumentException();

					_parent = value;
					ParentId = value.Id;
				}
			}
		}

		public ulong Size
		{
			get
			{
				return GetDirectorySize() + GetFileSize();
			}
		}

		public static Directory Create(string name, Directory parent, IDateTimeProvider dateTimeProvider)
		{
			return new Directory()
			{
				Id = Guid.NewGuid(),
				Parent = parent,
				Name = name,
				Created = dateTimeProvider.UtcNow
			};
		}

		private ulong GetFileSize()
		{
			if (Files == null)
				return 0;

			ulong size = 0;
			foreach (var file in Files)
				size += file.Size;
			return size;
		}

		private ulong GetDirectorySize()
		{
			if (Directories == null)
				return 0;

			ulong size = 0;
			foreach (var dir in Directories)
				size += dir.Size;
			return size;
		}

		public override string ToString()
		{
			return $"Name = {Name}, Directories = {Directories.Count}, Files = {Files.Count}";
		}

	}
}
