namespace LogACat.Engine
{
	public class FileItem : Item
	{
		ulong _size;

		public FileItem()
		{
		}

		public FileItem(ulong size)
		{
			_size = size;
		}

		public override ulong Size
		{
			get { return _size; }
		}
	}
}
