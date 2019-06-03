using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Exmo
{
	public class Client
	{
		private string apiKey = "";
		private string apiSecret = "";
		private string apiPath = "https://api.exmo.com/v1";

		//private IServiceClient CreateClient() => new JsonServiceClient("https://api.exmo.com/v1");

		public IServiceClient ServiceClient { get; set; }

		public Client(string apikey, string apisecret, string apipath = "")
		{
			apiKey = apikey;
			apiSecret = apisecret;
			if (apipath != "") apiPath = apipath;

			//ServiceClient = CreateClient();
			ServiceClient = new JsonServiceClient(apiPath);
		}

		public List<object> GetListSymbols()
		{
			var result = ServiceClient.Get(new PairSettings());

			return new List<object>();
		}
		public GetTickersResponse GetTickers(string symbol = "")
		{
			var result = ServiceClient.Get(new GetTickers());

			return result;
		}
		public OrderbookPublicResponse GetOrderbookPublic(string symbol = "", int limit = -1)
		{
			OrderbookPublic request = new OrderbookPublic();
			if (symbol != "") request.pair = symbol;
			if (limit > -1) request.Limit = limit;

			var result = ServiceClient.Get(request);

			return result;
		}
	}
}