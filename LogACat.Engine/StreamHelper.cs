﻿using System;
using System.IO;
using System.Security.Cryptography;

namespace LogACat.Engine
{
	public static class StreamHelper
	{
		public static string GetMD5Checksum(this Stream stream)
		{
			using (var md5 = MD5.Create())
			{
				//using (var stream = File.OpenRead(filename))
				var hash = md5.ComputeHash(stream);
				return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
			}
		}
	}
}
