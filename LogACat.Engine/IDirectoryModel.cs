using System;
using System.Collections.Generic;

namespace LogACat.Engine
{
	public interface IDirectoryModel
	{
		void AddDirectory(Directory directory);
		Directory GetDirectory(Guid id);
		Directory GetDirectory(string name, Guid? parentDirectoryId);
		IEnumerable<Directory> GetSubDirectories(Guid directoryId);
		void SetDirectoryName(Guid id, string name);
		void SetParentDirectory(Guid directoryId, Guid newParentDirectoryId);
		void DeleteDirectory(Guid id);
	}
}
