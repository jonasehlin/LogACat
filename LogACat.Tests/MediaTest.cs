using LogACat.Database;
using LogACat.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace LogACat.Tests
{
	[TestClass]
	public class MediaTest
	{
		[TestMethod]
		public void AddMedia()
		{
			var dateTimeProvider = new DateTimeProvider();

			var media = Media.Create("CD1", Directory.Create("Root", null, dateTimeProvider), dateTimeProvider);
			media.Root.Files.AddRange(new[]
			{
				File.Create(media.Root, "Fil01.txt", 1111, null, dateTimeProvider),
				File.Create(media.Root, "Fil02.txt", 2222, null, dateTimeProvider),
				File.Create(media.Root, "Fil03.txt", 3333, null, dateTimeProvider),
				File.Create(media.Root, "Fil04.txt", 4444, null, dateTimeProvider),
				File.Create(media.Root, "Fil05.txt", 5555, null, dateTimeProvider),
			});

			Assert.AreEqual(16665U, media.Root.Size);
		}

		[TestMethod]
		public void AddMediaToModel()
		{
			var dateTimeProvider = new DateTimeProvider();
			// Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jonas\Projekt\Privat\LogACat\LogACat.Database\LogACat.mdf;Integrated Security=True
			using (var db = new SqlConnection(Properties.Settings.Default.DbConnectionString))
			{
				IMediaModel model = new MediaModel(db);

				var media = model.GetMedia("TestCD1");
				if (media != null)
					model.DeleteMedia(media.Id);

				media = Media.Create("TestCD1", Directory.Create("Root", null, dateTimeProvider), dateTimeProvider);
				media.Root.Files.AddRange(new[]
				{
					File.Create(media.Root, "Fil01.txt", 1111, null, dateTimeProvider),
					File.Create(media.Root, "Fil02.txt", 2222, null, dateTimeProvider),
					File.Create(media.Root, "Fil03.txt", 3333, null, dateTimeProvider),
					File.Create(media.Root, "Fil04.txt", 4444, null, dateTimeProvider),
					File.Create(media.Root, "Fil05.txt", 5555, null, dateTimeProvider),
				});

				model.AddMedia(media);
			}
		}
	}
}
