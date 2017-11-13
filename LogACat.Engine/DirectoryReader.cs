using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogACat.Engine
{
	public class DirectoryReader : IDirectoryReader
	{
		public string Path { get; private set; }

		public DirectoryReader(string path)
		{
			Path = path;
		}

		public Directory ReadDirectory(Directory parentDirectory)
		{
			return Directory.Create(new DirectoryInfo(Path), parentDirectory);
		}
	}
}
