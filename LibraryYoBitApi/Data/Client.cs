using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Yobit
{
	public class Client
	{
		private string apiKey = "";
		private string apiSecret = "";
		private string apiPath = "https://yobit.net/api/1";

		//private IServiceClient CreateClient() => new JsonServiceClient("https://yobit.net/api/3");
		private IServiceClient CreateClientTrade() => new JsonServiceClient("https://yobit.net/tapi/");

		public IServiceClient ServiceClient { get; set; }
		public IServiceClient ServiceClientTrade { get; set; }

		public Client(string apikey, string apisecret, string apipath = "")
		{
			apiKey = apikey;
			apiSecret = apisecret;
			if (apipath != "") apiPath = apipath;

			//ServiceClient = CreateClient();
			ServiceClient = new JsonServiceClient(apiPath);
			ServiceClientTrade = CreateClientTrade();
		}

		/// <summary>
		/// Получение информации о парах
		/// https://yobit.net/ru/api/
		/// </summary>
		/// <returns>Получение информации о парах</returns>
		public async Task<GetInfoResponse> InfoAsync()
		{
			var response = await ServiceClient.GetAsync(new GetInfo());

			return response;
		}
		public GetInfoResponse Info()
		{
			var response = ServiceClient.Get(new GetInfo());

			return response;
		}
		public GetTickerResponse GetTickers(string symbol = "")
		{
			var response = ServiceClient.Get(new GetTicker());

			return response;
		}
	}
}
