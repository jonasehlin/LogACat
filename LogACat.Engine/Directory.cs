using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LogACat.Engine
{
	public class Directory
	{
		public Guid Id { get; set; }
		public Guid? ParentId { get; set; }
		public string Name { get; set; }
		public DateTime Created { get; set; }

		public readonly List<Directory> SubDirectories = new List<Directory>();
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

		public long Size
		{
			get
			{
				return CalculateDirectorySize() + CalculateFileSize();
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

		public static Directory Create(DirectoryInfo directoryInfo, Directory parent)
		{
			if (!directoryInfo.Exists)
				throw new DirectoryNotFoundException();

			var directory = new Directory()
			{
				Id = Guid.NewGuid(),
				Parent = parent,
				Name = directoryInfo.Name,
				Created = directoryInfo.CreationTimeUtc
			};
			directory.SubDirectories.AddRange(directoryInfo.EnumerateDirectories().Select(d => Create(d, directory)));
			directory.Files.AddRange(directoryInfo.EnumerateFiles().Select(f => File.Create(f, directory)));
			return directory;
		}

		private long CalculateFileSize()
		{
			if (Files == null)
				return 0;

			long size = 0;
			foreach (var file in Files)
				size += file.Size;

			return size;
		}

		private long CalculateDirectorySize()
		{
			if (SubDirectories == null)
				return 0;

			long size = 0;
			foreach (var dir in SubDirectories)
				size += dir.Size;

			return size;
		}

		public override string ToString()
		{
			return $"Name = {Name}, Directories = {SubDirectories.Count}, Files = {Files.Count}";
		}
	}
}
