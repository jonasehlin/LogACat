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
		public void CreateMedia()
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
			Directory dir01;
			media.Root.SubDirectories.AddRange(new[]
			{
				dir01 = Directory.Create("Dir01", media.Root, dateTimeProvider),
				Directory.Create("Dir02", media.Root, dateTimeProvider),
			});
			dir01.Files.AddRange(new[]
			{
				File.Create(dir01, "Fil01.txt", 1010, null, dateTimeProvider),
				File.Create(dir01, "Filter02.txt", 12345, null, dateTimeProvider),
				File.Create(dir01, "Fil03.txt", 444555666, null, dateTimeProvider),
			});
			Assert.AreEqual(444585686, media.Root.Size);
		}

		[TestMethod]
		public void AddMediaToModel()
		{
			var dateTimeProvider = new DateTimeProvider();
			// Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jonas\Projekt\Privat\LogACat\LogACat.Database\LogACat.mdf;Integrated Security=True
			using (var db = new SqlConnection(Properties.Settings.Default.DbConnectionString))
			{
				IFileModel fileModel = new FileModel(db);
				IMediaModel mediaModel = new MediaModel(db, new DirectoryModel(db, fileModel), fileModel);

				var media = mediaModel.GetMedia("TestCD1");
				if (media != null)
					mediaModel.DeleteMedia(media.Id);

				media = Media.Create("TestCD1", Directory.Create("TestRootCD1", null, dateTimeProvider), dateTimeProvider);
				media.Root.Files.AddRange(new[]
				{
					File.Create(media.Root, "Fil01.txt", 1111, null, dateTimeProvider),
					File.Create(media.Root, "Fil02.txt", 2222, null, dateTimeProvider),
					File.Create(media.Root, "Fil03.txt", 3333, null, dateTimeProvider),
					File.Create(media.Root, "Fil04.txt", 4444, null, dateTimeProvider),
					File.Create(media.Root, "Fil05.txt", 5555, null, dateTimeProvider),
				});

				mediaModel.AddMedia(media);
				mediaModel.DeleteMedia(media.Id);
			}
		}
	}
}
