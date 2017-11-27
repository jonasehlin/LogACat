using LogACat.Database;
using LogACat.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace LogACat.Tests
{
	[TestClass]
	public class DirectoryTest
	{
		[TestMethod]
		[TestCategory("Integration")]
		public void AddDirectoryToModel()
		{
			var dateTimeProvider = new DateTimeProvider();
			using (var db = new SqlConnection(Properties.Settings.Default.DbConnectionString))
			{
				IDirectoryModel directoryModel = new DirectoryModel(db, new FileModel(db));

				var directory = directoryModel.GetDirectory("TestRoot123", null);
				if (directory != null)
					directoryModel.DeleteDirectory(directory.Id);

				directory = Directory.Create("TestRoot123", null, dateTimeProvider);
				directoryModel.AddDirectory(directory);
				directoryModel.DeleteDirectory(directory.Id);
			}
		}
	}
}
