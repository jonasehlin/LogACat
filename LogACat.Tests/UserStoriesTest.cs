using LogACat.Database;
using LogACat.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace LogACat.Tests
{
	[TestClass]
	public class UserStoriesTest
	{
		[TestMethod]
		public void ReadMedia()
		{
			IDateTimeProvider dateTimeProvider = new SpecificDateTimeProvider(new DateTime(2017, 11, 14, 00, 39, 00, DateTimeKind.Utc));
			IMediaReader reader = new PathMediaReader(@"C:\Temp");
			var media = reader.ReadMedia(dateTimeProvider);
			Assert.AreEqual(@"C:\Temp", media.Name);

			using (var db = new SqlConnection(Properties.Settings.Default.DbConnectionString))
			{
				IModel model = new DatabaseModel(db);

				var oldMedia = model.Media.GetMedia(media.Name);
				if (oldMedia != null)
					model.Media.DeleteMedia(oldMedia);

				model.Media.AddMedia(media);
				Trace.WriteLine($"Media = {media}, Root.Size = {media.Root.Size} bytes");
			}
		}
	}
}
