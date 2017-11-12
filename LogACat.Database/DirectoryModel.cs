using Dapper;
using LogACat.Engine;
using System;
using System.Collections.Generic;
using System.Data;

namespace LogACat.Database
{
	public class DirectoryModel : IDirectoryModel
	{
		IDbConnection _db;

		public DirectoryModel(IDbConnection db)
		{
			if (db.State == ConnectionState.Closed)
				db.Open();
			_db = db;
		}

		public void AddDirectory(Directory directory)
		{
			_db.Execute(@"
INSERT INTO [dbo].[Directory] ([Id], [ParentId], [Name], [Created])
VALUES (@Id, @ParentId, @Name, @Created)",
				new { directory.Id, directory.ParentId, directory.Name, directory.Created });
			
			// TODO: Add sub directories.
			// TODO: Add files
		}

		public void DeleteDirectory(Guid id)
		{
			_db.Execute("DELETE FROM [dbo].[Directory] WHERE @Id = @id", new { id });
		}

		public Directory GetDirectory(Guid id)
		{
			return _db.QuerySingleOrDefault<Directory>("SELECT [Id], [ParentId], [Name], [Created] FROM [dbo].[Directory] WHERE [Id] = @id",
				new { id });
		}

		public Directory GetDirectory(string name, Guid? parentDirectoryId)
		{
			return _db.QuerySingleOrDefault<Directory>(@"
SELECT [Id], [ParentId], [Name], [Created] FROM [dbo].[Directory]
WHERE ((@parentDirectoryId IS NULL AND [ParentId] IS NULL) OR (@parentDirectoryId IS NOT NULL AND [ParentId] = @parentDirectoryId))
AND [Name] = @name",
				new { name, parentDirectoryId });
		}

		public IEnumerable<Directory> GetSubDirectories(Guid directoryId)
		{
			throw new NotImplementedException();
		}

		public void SetDirectoryName(Guid id, string name)
		{
			throw new NotImplementedException();
		}

		public void SetParentDirectory(Guid directoryId, Guid newParentDirectoryId)
		{
			throw new NotImplementedException();
		}
	}
}
