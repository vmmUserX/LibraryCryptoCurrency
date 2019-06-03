using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.KuCoin
{
	public class Client
	{
		private string apiKey = "";
		private string apiSecret = "";
		private string apiPath = "https://api.kucoin.com";

		//private IServiceClient CreateClient() => new JsonServiceClient("https://api.kucoin.com");

		public IServiceClient ServiceClient { get; set; }

		public Client(string apikey, string apisecret, string apipath = "")
		{
			apiKey = apikey;
			apiSecret = apisecret;
			if (apipath != "") apiPath = apipath;

			//ServiceClient = CreateClient();
			ServiceClient = new JsonServiceClient(apiPath);
		}

		public TickResponse GetTickers(string symbol = "")
		{
			var result = ServiceClient.Get(new Tick());

			return result;
		}
		public OrderbookPublicResponse GetOrderbookPublic(string symbol = "", int limit = -1)
		{
			OrderbookPublic request = new OrderbookPublic();
			if (symbol != "") request.symbol = symbol;
			if (limit > -1) request.limit = limit;

			var result = ServiceClient.Get(request);

			return result;
		}
	}
}