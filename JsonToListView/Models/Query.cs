using System;

namespace JsonToListView
{
	public class Query
	{
		public Query ()
		{
		}

		public string Text { get; set; }
	}

	public class RootObject
	{
		public Query[] RelatedTopics { get; set; }
	}
}
