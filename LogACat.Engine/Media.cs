using System;

namespace LogACat.Engine
{
	public class Media
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public Guid? RootId { get; set; }

		public Directory Root
		{
			get;
			set;
		}
	}
}
