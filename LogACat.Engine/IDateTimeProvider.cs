using System;

namespace LogACat.Engine
{
	public interface IDateTimeProvider
	{
		DateTime UtcNow { get; }
	}
}
