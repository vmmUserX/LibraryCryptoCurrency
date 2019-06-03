using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Hitbtc
{
	public enum TradeSide
	{
		[EnumMember(Value = "buy")]
		Buy,
		[EnumMember(Value = "sell")]
		Sell
	}
	public enum TradeType
	{
		[EnumMember(Value = "limit")]
		Limit,
		[EnumMember(Value = "market")]
		Market,
		[EnumMember(Value = "stopLimit")]
		StopLimit,
		[EnumMember(Value = "stopMarket")]
		StopMarket
	}
	public enum TimeInForce
	{
		[EnumMember(Value = "GTC")]
		GTC,
		[EnumMember(Value = "IOC")]
		IOC,
		[EnumMember(Value = "FOK")]
		FOK,
		[EnumMember(Value = "Day")]
		Day,
		[EnumMember(Value = "GTD")]
		GTD
	}
	public enum SortDirection
	{
		[EnumMember(Value = "DESC")]
		Desc,
		[EnumMember(Value = "ASC")]
		Asc
	}
	public class Client
	{
		private string apiKey = "";
		private string apiSecret = "";
		private string apiPath = "https://api.hitbtc.com";
		//private string apiPath = "https://demo-api.hitbtc.com";

		//private IServiceClient CreateClient() => new JsonServiceClient("https://api.hitbtc.com");

		public IServiceClient ServiceClient { get; set; }

		public Client(string apikey, string apisecret, string apipath = "")
		{
			apiKey = apikey;
			apiSecret = apisecret;
			if (apipath != "") apiPath = apipath;

			//ServiceClient = CreateClient();
			ServiceClient = new JsonServiceClient(apiPath);
		}

		public List<CurrenciesResponse> GetCurrenciesList()
		{
			var result = ServiceClient.Get(new CurrenciesList());

			return result;
		}
		public CurrenciesResponse GetCurrencies(string nameCurrency)
		{
			var result = ServiceClient.Get(new Currencies() { Currency = nameCurrency });

			return result;
		}
		public List<SymbolsResponse> GetSymbolsList()
		{
			var result = ServiceClient.Get(new SymbolsList());

			return result;
		}
		public SymbolsResponse GetSymbols(string nameSymbol)
		{
			var result = ServiceClient.Get(new Symbols() { Symbol = nameSymbol });

			return result;
		}
		public List<BalanceCurrencyDetail> GetBalanceCurrency()
		{
			var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(apiKey + ":" + apiSecret));
			ServiceClient.AddHeader("Authorization", "Basic " + encoded);

			List<BalanceCurrencyDetail> result = ServiceClient.Get(new BalanceCurrency());

			return result;
		}
		public ActiveOrdersResponse GetActiveOrders(string symbol = "")
		{
			var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(apiKey + ":" + apiSecret));
			ServiceClient.AddHeader("Authorization", "Basic " + encoded);

			ActiveOrders request = new ActiveOrders();
			if (symbol != "") request.Symbol = symbol;

			var result = ServiceClient.Get(request);

			return result;
		}
		public TickerInfoResponse GetTickers(string symbol = "")
		{
			var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(apiKey + ":" + apiSecret));
			ServiceClient.AddHeader("Authorization", "Basic " + encoded);

			TickerInfo request = new TickerInfo();
			if (symbol != "") request.Symbol = symbol;

			var result = ServiceClient.Get(request);

			return result;
		}
		public TradesPublicResponse GetTradesPublic(string symbol = "", string sort = "", string by = "", string from = "", string till = "", int limit = -1, int offset = -1)
		{
			TradesPublic request = new TradesPublic();
			if (symbol != "") request.Symbol = symbol;
			if (sort != "") request.Sort = sort;
			if (by != "") request.By = by;
			if (from != "") request.From = from;
			if (till != "") request.Till = till;
			if (limit > -1) request.Limit = limit;
			if (offset > -1) request.Offset = offset;

			var result = ServiceClient.Get(request);

			return result;
		}
		public OrderbookPublicResponse GetOrderbookPublic(string symbol = "", int limit = -1)
		{
			OrderbookPublic request = new OrderbookPublic();
			if (symbol != "") request.Symbol = symbol;
			if (limit > -1) request.Limit = limit;

			var result = ServiceClient.Get(request);

			return result;
		}
		public NewOrderResponse CreateNewOrder(string symbol, string side, double quantity, double price = -1, double stopPrice = -1,
				string timeInForce = "Day", DateTime expireTime = default, string clientOrderId = null, bool strictValidate = true)
		{
			string orderType = "market";

			if (price != -1 && stopPrice == -1) orderType = "limit";
			else if (price == -1 && stopPrice != -1) orderType = "stopMarket";
			else if (price != -1 && stopPrice != -1) orderType = "stopLimit";

			var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(apiKey + ":" + apiSecret));
			ServiceClient.AddHeader("Authorization", "Basic " + encoded);
			
			NewOrder request = new NewOrder()
			{
				ClientOrderId = clientOrderId,
				Symbol = symbol,
				Side = side,
				TypeOrder = orderType,
				TimeInForce = timeInForce,
				Quantity = quantity,
				Price = price,
				StopPrice = stopPrice,
				ExpireTime = expireTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff'Z'"),
				StrictValidate = strictValidate
			};

			if (clientOrderId != null)
			{
				request.ClientOrderId = clientOrderId;
				NewOrderResponse resultPut = ServiceClient.Put(request);

				return resultPut;
			}
			else
			{
				NewOrderResponse resultPost = ServiceClient.Post(request);

				return resultPost;
			}
		}
		public CancelOrdersResponse SetCancelOrders(string symbol = "")
		{
			CancelOrders request = new CancelOrders();
			if (symbol != "") request.Symbol = symbol;

			var result = ServiceClient.Delete(request);

			return result;
		}
		public CancelOrderResponse SetCancelOrder(string clientOrderId, string symbol = "")
		{
			CancelOrder request = new CancelOrder() { ClientOrderId = clientOrderId };
			if (symbol != "") request.Symbol = symbol;

			var result = ServiceClient.Delete(request);

			return result;
		}
	}
}