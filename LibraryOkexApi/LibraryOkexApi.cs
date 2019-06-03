using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryExchangeInterface.Data.Okex;

namespace LibraryExchangeInterface
{
	public class LibraryOkexApi : IExchangeInterface
	{
		#region IExchangeInterface: Variables
		/// <summary>
		/// Системное название библиотеки (DLL)
		/// </summary>
		public string LibraryName { get { return "OKEx".ToLower(); } }
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		public bool LibraryEnabled { get { return libraryEnabled; } }
		#endregion IExchangeInterface: End Variables

		#region Variables
		private Client okexClient { get; set; }
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		private bool libraryEnabled = false;
		#endregion End Variables

		/// <summary>
		/// Конструктор библиотеки OKEX без указания путей в конструкторе
		/// </summary>
		public LibraryOkexApi()
		{
		}

		#region IExchangeInterface: Functions
		/// <summary>
		/// Инициализация библиотеки. Используются значения по умолчанию
		/// </summary>
		public void LibraryInit()
		{
			okexClient = new Client("Key", "Secret");

			libraryEnabled = true;
		}
		/// <summary>
		/// Инициализация библиотеки. Используются внешние значения для аргументов
		/// </summary>
		public void LibraryInit(string apiKey, string apiSecret, string apiPath = "")
		{
			okexClient = new Client(apiKey, apiSecret, apiPath);

			libraryEnabled = true;
		}
		/// <summary>
		/// Инициализация библиотеки через соккет
		/// </summary>
		public void LibraryInitSocket() { }

		public List<CurrencyInfo> GetListCurrency()
		{
			return new List<CurrencyInfo>();
		}
		public List<SymbolPairsInfo> GetListSymbols()
		{
			return new List<SymbolPairsInfo>();
		}
		public List<BalanceCurrency> GetBalanceCurrencies()
		{
			return new List<BalanceCurrency>();
		}
		public List<ActiveOrder> GetActiveOrders()
		{
			return new List<ActiveOrder>();
		}
		public List<TickerInformation> GetTickers()
		{
			TickerResponse response = okexClient.GetTickers();

			List<TickerInformation> result = new List<TickerInformation>();

			foreach (TickerDetail ti in response)
			{
				DateTime parsedDate = DateTime.Parse(ti.Timestamp);
				string str = Helpers.GetServerTimeTicks((int)DateTicksType.Epoch, parsedDate);
				Int64 timestamp = Convert.ToInt64(str) * 1000 + parsedDate.Millisecond;
				//Int64 timestamp = Convert.ToInt64(str);

				//Debug.WriteLine(String.Format("originalDate = {0} parsedDate = {1} timestamp = {2}", ti.Timestamp, parsedDate, timestamp));

				string[] strArray = ti.InstrumentId.Split('-');
				string symbol = String.Format("{0}-{1}", strArray[0], strArray[1]);

				TickerInformation tickerInfo = new TickerInformation()
				{
					Ask = ti.BestAsk,
					Bid = ti.BestBid,
					Last = ti.Last,
					Open = ti.Last,
					Low = ti.Low24h,
					High = ti.High24h,
					Volume = ti.Volume24h,
					VolumeQuote = default,
					TimestampOpen = timestamp,
					DateTimeOpenOrig = ti.Timestamp,
					TimestampClose = timestamp,
					DateTimeCloseOrig = ti.Timestamp,
					Symbol = symbol
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
			OrderbookPublicResponse response = okexClient.GetOrderbookPublic(symbol, limit);

			OrderbookPublicInformation result = new OrderbookPublicInformation()
			{
				Datetime = response.Timestamp,
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
