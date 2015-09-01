using System;

namespace JsonToListView
{
	public class Topic
	{
		public string FirstURL { get; set; }
		public string Text { get; set; }
	}

	public class RelatedTopic
	{
		public RelatedTopic ()
		{
		}

//		public string Result { get; set; }
//		public string Icon { get; set; }
		public string FirstURL { get; set; }
		public string Text { get; set; }
		public Topic[] Topics { get; set; }
	}

	public class RootObject
	{
		public RelatedTopic[] RelatedTopics { get; set; }
	}
}
