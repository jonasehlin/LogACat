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
		public void AddDirectoryToModel()
		{
			var dateTimeProvider = new DateTimeProvider();
			using (var db = new SqlConnection(Properties.Settings.Default.DbConnectionString))
			{
				IDirectoryModel model = new DirectoryModel(db);

				var directory = model.GetDirectory("TestRoot123", null);
				if (directory != null)
					model.DeleteDirectory(directory.Id);

				directory = Directory.Create("TestRoot123", null, dateTimeProvider);
				model.AddDirectory(directory);
				model.DeleteDirectory(directory.Id);
			}
		}
	}
}
