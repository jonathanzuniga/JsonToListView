using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonToListView
{
	public class RestService
	{
		public RestService ()
		{
		}

		public async Task<Query[]> GetQueriesAsync () {
			var client = new System.Net.Http.HttpClient ();

			client.BaseAddress = new Uri("http://api.duckduckgo.com/");

			var response = await client.GetAsync("?q=mexico&format=json&pretty=1");
			var queriesJson = response.Content.ReadAsStringAsync().Result;
			var rootObject = JsonConvert.DeserializeObject<RootObject>(queriesJson);

			return rootObject.RelatedTopics;
		}
	}
}
