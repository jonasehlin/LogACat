using System;
using System.Collections.Generic;

namespace LogACat.Engine
{
	public interface IMediaModel
	{
		void AddMedia(Media media);
		IEnumerable<Media> GetMedia();
		Media GetMedia(Guid id);
		Media GetMedia(string name);
		void UpdateMedia(Guid id, Media media);
		void DeleteMedia(Guid id);
		void DeleteMedia(Media media);
	}
}
