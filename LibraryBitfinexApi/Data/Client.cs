using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Bitfinex
{
	public class Client
	{
		private string apiKey = "";
		private string apiSecret = "";
		private string apiPath = "https://api.bitfinex.com/v1";

		//private IServiceClient CreateClient() => new JsonServiceClient("https://api.bitfinex.com/v2");

		public IServiceClient ServiceClient { get; set; }

		public Client(string apikey, string apisecret, string apipath = "")
		{
			apiKey = apikey;
			apiSecret = apisecret;
			if (apipath != "") apiPath = apipath;

			//ServiceClient = CreateClient();
			ServiceClient = new JsonServiceClient(apiPath);
		}

		public GetTickerResponse GetTickers(string symbols = "")
		{
			var symbolsEnum = symbols == "" ? "ALL" : symbols;

			var result = ServiceClient.Get(new GetTickers() { Symbols = symbolsEnum });

			return result;
		}
		public OrderbookPublicResponse GetOrderbookPublic(string symbol = "", int limit = -1)
		{
			OrderbookPublic request = new OrderbookPublic();
			if (symbol != "") request.Symbols = symbol;
			if (limit > -1)
			{
				request.LimitAsks = limit;
				request.LimitBids = limit;
			}

			var result = ServiceClient.Get(request);

			return result;
		}
	}
}