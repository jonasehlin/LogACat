using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogACat.Engine;

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
			Assert.AreEqual(@"C:\", media.Name);
		}
	}
}
