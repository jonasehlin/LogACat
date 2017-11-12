using LogACat.Database;
using System.Collections.Generic;

namespace LogACat.Engine
{
	public class Media
	{
		public string Name { get; set; }

		public readonly List<Item> Content = new List<Item>();

		public void ReadContent(IEnumerable<FilePost> filePosts)
		{
			foreach (var filePost in filePosts)
			{
				switch (filePost.Type)
				{
					case FilePostType.File:
						break;
					case FilePostType.Directory:
						break;

					case FilePostType.None:
					default:
						break;
				}
			}
		}
	}
}
