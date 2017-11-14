using Dapper;
using LogACat.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LogACat.Database
{
	public class MediaModel : IMediaModel
	{
		IDbConnection _db;
		IDirectoryModel _directoryModel;
		IFileModel _fileModel;

		public MediaModel(IDbConnection db, IDirectoryModel directoryModel, IFileModel fileModel)
		{
			if (db.State == ConnectionState.Closed)
				db.Open();
			_db = db;
			_directoryModel = directoryModel;
			_fileModel = fileModel;
		}

		public void AddMedia(Media media)
		{
			_directoryModel.AddDirectory(media.Root);

			_db.Execute(@"
INSERT INTO [dbo].[Media] ([Id], [Name], [Created], [Updated], [RootId])
VALUES (@Id, @Name, @Created, @Updated, @RootId)",
			new { media.Id, media.Name, media.Created, media.Updated, media.RootId });
		}

		public void DeleteMedia(Guid id)
		{
			DeleteMedia(GetMedia(id));
		}

		public void DeleteMedia(Media media)
		{
			if (media.RootId.HasValue)
			{
				// Not necessary to delete the Media because the Directory-FK cascades on delete
				_directoryModel.DeleteDirectory(media.RootId.Value);
			}
			else
			{
				_db.Execute("DELETE FROM [dbo].[Media] WHERE [Id] = @Id", new { media.Id });
			}
		}

		public IEnumerable<Media> GetMedia()
		{
			return _db.Query<Media>("SELECT [Id], [Name], [Created], [Updated], [RootId] FROM [dbo].[Media]").OrderBy(m => m.Name);
		}

		public Media GetMedia(Guid id)
		{
			return _db.QuerySingleOrDefault<Media>("SELECT [Id], [Name], [Created], [Updated], [RootId] FROM [dbo].[Media] WHERE [Id] = @id",
				new { id });
		}

		public Media GetMedia(string name)
		{
			return _db.QuerySingleOrDefault<Media>("SELECT [Id], [Name], [Created], [Updated], [RootId] FROM [dbo].[Media] WHERE [Name] = @name",
				new { name });
		}

		public void UpdateMedia(Guid id, Media media)
		{
			_db.Execute(@"
UPDATE [dbo].[Media] SET [Id] = @Id, [Name] = @Name, [Created] = @Created, [Updated] = @Updated, [RootId] = @RootId
WHERE [Id] = @id",
			new { media.Id, media.Name, media.Created, media.Updated, media.RootId });
		}
	}
}
