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

		private Directory _root;

		public Directory Root
		{
			get { return _root; }
			set
			{
				if (value == null)
				{
					_root = null;
					RootId = null;
				}
				else
				{
					if (value.Id == Id)
						throw new ArgumentException();

					_root = value;
					RootId = value.Id;
				}
			}
		}

		public static Media Create(string name, Directory root, IDateTimeProvider dateTimeProvider)
		{
			var now = dateTimeProvider.UtcNow;
			return new Media()
			{
				Id = Guid.NewGuid(),
				Name = name,
				Created = now,
				Updated = now,
				Root = root
			};
		}
	}
}
