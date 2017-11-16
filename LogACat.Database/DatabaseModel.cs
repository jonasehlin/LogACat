using LogACat.Engine;
using System.Data;

namespace LogACat.Database
{
	public class DatabaseModel : IModel
	{
		public IMediaModel Media
		{
			get; private set;
		}

		public DatabaseModel(IDbConnection db)
		{
			IFileModel fileModel = new FileModel(db);
			Media = new MediaModel(db, new DirectoryModel(db, fileModel), fileModel);
		}
	}
}
