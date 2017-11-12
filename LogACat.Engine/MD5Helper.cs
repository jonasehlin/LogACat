using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LogACat.Engine
{
	public static class MD5Helper
	{
		public static byte[] GetMD5Checksum(this Stream stream)
		{
			using (var md5 = MD5.Create())
			{
				//using (var stream = File.OpenRead(filename))
				return md5.ComputeHash(stream);
			}
		}

		public static byte[] GetMD5Hash(this string s)
		{
			using (var md5 = MD5.Create())
			{
				return md5.ComputeHash(Encoding.UTF8.GetBytes(s));
			}
		}

		public static string ToMD5String(this byte[] hash)
		{
			return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
		}
	}
}
