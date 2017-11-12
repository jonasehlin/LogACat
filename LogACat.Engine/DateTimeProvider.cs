using System;

namespace LogACat.Engine
{
	public class DateTimeProvider : IDateTimeProvider
	{
		public DateTime UtcNow
		{
			get { return DateTime.UtcNow; }
		}
	}
}
