using LogACat.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogACat.Tests
{
	[TestClass]
	public class ChecksumTest
	{
		[TestMethod]
		public void GenerateMD5ChecksumTest()
		{
			var hash = "apansson".GetMD5Hash();
			Assert.AreEqual(16, hash.Length);
			var hashString = hash.ToMD5String();
			Assert.AreEqual(32, hashString.Length);
			Assert.AreEqual("0e35c2c4dedabeb615a28175bcd64f9c", hashString);
		}
	}
}
