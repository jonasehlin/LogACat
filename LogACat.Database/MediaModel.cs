using Dapper;
using LogACat.Engine;
using System;
using System.Collections.Generic;
using System.Data;

namespace LogACat.Database
{
	public class MediaModel : IMediaModel
	{
		IDbConnection _db;

		public MediaModel(IDbConnection db)
		{
			db.Open();
			_db = db;
		}

		public void AddMedia(Media media)
		{
			_db.Execute(@"
INSERT INTO [dbo].[Media] ([Id], [Name], [Created], [Updated], [RootId])
VALUES (@Id, @Name, @Created, @Updated, @RootId)",
			new { media.Id, media.Name, media.Created, media.Updated, media.RootId });
		}

		public void DeleteMedia(Guid id)
		{
			_db.Execute("DELETE FROM [dbo].[Media] WHERE [Id] = @id", new { id });
		}

		public IEnumerable<Media> GetMedia()
		{
			return _db.Query<Media>("SELECT [Id], [Name], [Created], [Updated], [RootId] FROM [dbo].[Media]");
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
