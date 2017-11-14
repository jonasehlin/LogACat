using System.IO;

namespace LogACat.Engine
{
	public class PathMediaReader : IMediaReader
	{
		public string Path { get; private set; }

		public PathMediaReader(string path)
		{
			Path = path;
		}

		public Media ReadMedia(IDateTimeProvider dateTimeProvider)
		{
			var directoryInfo = new DirectoryInfo(Path);
			return Media.Create(directoryInfo.FullName, Directory.Create(directoryInfo, null), dateTimeProvider);
		}
	}
}
