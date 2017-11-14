using System;
using System.Collections.Generic;

namespace LogACat.Engine
{
	public interface IFileModel
	{
		void AddFile(File file);
		File GetFile(Guid id);
		IEnumerable<File> GetFiles(Guid directoryId);
		void DeleteFiles(Guid directoryId);
	}
}
