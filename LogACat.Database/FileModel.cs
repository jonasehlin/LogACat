using Dapper;
using LogACat.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LogACat.Database
{
	public class FileModel : IFileModel
	{
		IDbConnection _db;

		public FileModel(IDbConnection db)
		{
			if (db.State == ConnectionState.Closed)
				db.Open();
			_db = db;
		}

		public void AddFile(File file)
		{
			_db.Execute(@"
INSERT INTO [dbo].[File] ([Id], [DirectoryId], [Name], [Size], [Created], [Modified], [Checksum])
VALUES (@Id, @DirectoryId, @Name, @Size, @Created, @Modified, @Checksum)",
				new { file.Id, file.DirectoryId, file.Name, file.Size, file.Created, file.Modified, file.Checksum });
		}

		public void DeleteFiles(Guid directoryId)
		{
			_db.Execute("DELETE FROM [dbo].[File] WHERE [DirectoryId] = @directoryId", new { directoryId });
		}

		public File GetFile(Guid id)
		{
			return _db.QuerySingleOrDefault<File>(@"
SELECT [Id], [DirectoryId], [Name], [Size], [Created], [Modified], [Checksum]
FROM [dbo].[File]
WHERE [Id] = @id",
				new { id });
		}

		public IEnumerable<File> GetFiles(Guid directoryId)
		{
			return _db.Query<File>(@"
SELECT [Id], [DirectoryId], [Name], [Size], [Created], [Modified], [Checksum]
FROM [dbo].[File]
WHERE [DirectoryId] = @directoryId",
				new { directoryId }).OrderBy(f => f.Name);
		}
	}
}
