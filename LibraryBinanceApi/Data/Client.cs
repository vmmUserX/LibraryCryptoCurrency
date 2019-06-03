using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Binance
{
	public class Client
	{
		private string apiKey = "";
		private string apiSecret = "";
		private string apiPath = "https://api.binance.com";

		//private IServiceClient CreateClient() => new JsonServiceClient("https://api.binance.com");

		public IServiceClient ServiceClient { get; set; }

		public Client(string apikey, string apisecret, string apipath = "")
		{
			apiKey = apikey;
			apiSecret = apisecret;
			if (apipath != "") apiPath = apipath;

			//ServiceClient = CreateClient();
			ServiceClient = new JsonServiceClient(apiPath);
		}

		public Statistics24HourResponse GetTickers(string symbol = "")
		{
			var result = ServiceClient.Get(new Statistics24Hour());

			return result;
		}
		public GetDepthsResponse GetDepth(string symbol = "", int limit = default)
		{
			GetDepths gd = new GetDepths();
			if (symbol != "") gd.symbol = symbol;
			if (limit != default) gd.limit = limit;

			var result = ServiceClient.Get(gd);

			return result;
		}
	}
}