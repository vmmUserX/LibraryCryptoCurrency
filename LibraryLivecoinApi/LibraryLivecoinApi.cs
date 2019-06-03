using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryExchangeInterface.Data.Livecoin;

namespace LibraryExchangeInterface
{
	public class LibraryLivecoinApi : IExchangeInterface
	{
		#region IExchangeInterface: Variables
		/// <summary>
		/// Системное название библиотеки (DLL)
		/// </summary>
		public string LibraryName { get { return "Livecoin".ToLower(); } }
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		public bool LibraryEnabled { get { return libraryEnabled; } }
		#endregion IExchangeInterface: End Variables

		#region Variables
		private Client livecoinClient { get; set; }
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		private bool libraryEnabled = false;
		#endregion End Variables

		/// <summary>
		/// Конструктор библиотеки Livecoin без указания путей в конструкторе
		/// </summary>
		public LibraryLivecoinApi()
		{
		}

		#region IExchangeInterface: Functions
		/// <summary>
		/// Инициализация библиотеки. Используются значения по умолчанию
		/// </summary>
		public void LibraryInit()
		{
			livecoinClient = new Client("Key", "Secret");

			libraryEnabled = true;
		}
		/// <summary>
		/// Инициализация библиотеки. Используются внешние значения для аргументов
		/// </summary>
		public void LibraryInit(string apiKey, string apiSecret, string apiPath = "")
		{
			livecoinClient = new Client(apiKey, apiSecret, apiPath);

			libraryEnabled = true;
		}
		/// <summary>
		/// Инициализация библиотеки через соккет
		/// </summary>
		public void LibraryInitSocket() { }

		public List<CurrencyInfo> GetListCurrency()
		{
			return null;
		}
		public List<SymbolPairsInfo> GetListSymbols()
		{
			List<SymbolPairsInfo> result = new List<SymbolPairsInfo>();

			RestrictionsResponse coinInfo = livecoinClient.GetRestriction();

			foreach (Restriction restr in coinInfo.Restrictions)
			{
				result.Add(new SymbolPairsInfo() { Name = restr.CurrencyPair, LimitNumberDecimalPlaces = Convert.ToInt32(restr.PriceScale) });
			}

			return result;
		}
		public List<BalanceCurrency> GetBalanceCurrencies()
		{
			List<BalanceCurrency> result = new List<BalanceCurrency>();

			List<BalancesInfo> balancesInfos = livecoinClient.GetBalances();

			return new List<BalanceCurrency>();
		}
		public List<ActiveOrder> GetActiveOrders()
		{
			return new List<ActiveOrder>();
		}
		public List<TickerInformation> GetTickers()
		{
			TickerResponse response = livecoinClient.GetTickers();

			List<TickerInformation> result = new List<TickerInformation>();

			foreach(TickerPairResponse ti in response)
			{
				TickerInformation tickerInfo = new TickerInformation()
				{
					Ask = ti.BestAsk,
					Bid = ti.BestBid,
					Last = ti.Last,
					Open = default,
					Low = ti.Low,
					High = ti.High,
					Volume = ti.Volume,
					VolumeQuote = ti.Vwap,
					TimestampOpen = default,
					DateTimeOpenOrig = default,
					TimestampClose = default,
					DateTimeCloseOrig = default,
					Symbol = ti.Symbol
				};

				result.Add(tickerInfo);
			}

			return result;
		}
		public List<TradesPublicInformation> GetTradesPublic(string symbol = "", string sort = "", string by = "", string from = "", string till = "", int limit = -1, int offset = -1)
		{
			return new List<TradesPublicInformation>();
		}
		public OrderbookPublicInformation GetOrderbookPublic(string symbol = "", int limit = -1)
		{
			OrderBookResponse response = livecoinClient.GetOrderBook(symbol, limit);

			OrderbookPublicInformation result = new OrderbookPublicInformation()
			{
				Datetime = response.Timestamp.ToString(),
				Ask = new List<OrderbookPublicInfoDetail>(),
				Bid = new List<OrderbookPublicInfoDetail>()
			};

			foreach (var index in response.Asks)
			{
				OrderbookPublicInfoDetail detailNew = new OrderbookPublicInfoDetail()
				{
					Price = Convert.ToDouble(index[0], CultureInfo.InvariantCulture),
					Size = Convert.ToDouble(index[1], CultureInfo.InvariantCulture)
				};

				result.Ask.Add(detailNew);
			}

			foreach (var index in response.Bids)
			{
				OrderbookPublicInfoDetail detailNew = new OrderbookPublicInfoDetail()
				{
					Price = Convert.ToDouble(index[0], CultureInfo.InvariantCulture),
					Size = Convert.ToDouble(index[1], CultureInfo.InvariantCulture)
				};

				result.Bid.Add(detailNew);
			}

			return result;
		}
		public OrderInformation CreateNewOrder(string symbol, string side, double quantity, double price = -1, double stopPrice = -1,
				string timeInForce = "Day", DateTime expireTime = default, string clientOrderId = null, bool strictValidate = true)
		{
			OrderInformation result = new OrderInformation()
			{
			};

			return result;
		}
		/// <summary>
		/// Cancel all active orders, or all active orders for specified symbol
		/// </summary>
		/// <param name="symbol">Optional parameter to filter active orders by symbol</param>
		public List<OrderInformation> SetCancelOrders(string symbol = "")
		{
			List<OrderInformation> result = new List<OrderInformation>();

			return result;
		}
		/// <summary>
		/// Cancel order for specified symbol by clientOrderId
		/// </summary>
		/// <param name="symbol">Optional parameter to filter active orders by symbol</param>
		public OrderInformation SetCancelOrder(string clientOrderId, string symbol = "")
		{
			OrderInformation result = new OrderInformation()
			{
			};

			return result;
		}
		#endregion IExchangeInterface: End Functions
	}
}