using System;

namespace LogACat.Engine
{
	public class SpecificDateTimeProvider : IDateTimeProvider
	{
		private DateTime _utcNow;

		public SpecificDateTimeProvider(DateTime utcNow)
		{
			_utcNow = utcNow;
		}

		public DateTime UtcNow
		{
			get { return _utcNow; }
		}
	}
}
