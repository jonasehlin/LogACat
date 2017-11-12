namespace LogACat.Engine
{
	public abstract class Item
    {
		public string Name { get; set; }

		public abstract ulong Size
		{
			get;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
