using System.IO;

namespace LogACat.Engine
{
	public class FileReader : IFileReader
	{
		public string Path { get; private set; }

		public FileReader(string path)
		{
			Path = path;
		}

		public File ReadFile(Directory parentDirectory)
		{
			return File.Create(new FileInfo(Path), parentDirectory);
		}
	}
}
