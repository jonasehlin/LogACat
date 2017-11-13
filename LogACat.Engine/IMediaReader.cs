namespace LogACat.Engine
{
	public interface IMediaReader
	{
		Media ReadMedia(IDateTimeProvider dateTimeProvider);
	}
}
