﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Okex
{
	public class Client
	{
		private string apiKey = "";
		private string apiSecret = "";
		private string apiPath = "https://www.okex.com/";

		//private IServiceClient CreateClient() => new JsonServiceClient("https://www.okex.com/");

		public IServiceClient ServiceClient { get; set; }

		public Client(string apikey, string apisecret, string apipath = "")
		{
			apiKey = apikey;
			apiSecret = apisecret;
			if (apipath != "") apiPath = apipath;

			//ServiceClient = CreateClient();
			ServiceClient = new JsonServiceClient(apiPath);
		}

		public TickerResponse GetTickers(string symbol = "")
		{
			var result = ServiceClient.Get(new Ticker());

			return result;
		}
		public OrderbookPublicResponse GetOrderbookPublic(string symbol = "", int limit = -1)
		{
			OrderbookPublic request = new OrderbookPublic();
			if (symbol != "") request.Symbol = symbol;
			if (limit > -1) request.size = limit;

			var result = ServiceClient.Get(request);

			return result;
		}
	}
}