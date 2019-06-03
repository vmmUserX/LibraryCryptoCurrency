using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryExchangeInterface.Data.Bitfinex;
using ServiceStack;

namespace LibraryExchangeInterface
{
	public class LibraryBitfinexApi : IExchangeInterface
	{
		#region IExchangeInterface: Variables
		/// <summary>
		/// Системное название библиотеки (DLL)
		/// </summary>
		public string LibraryName { get { return "Bitfinex".ToLower(); } }
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		public bool LibraryEnabled { get { return libraryEnabled; } }
		#endregion IExchangeInterface: End Variables

		#region Variables
		private Client bitfinexClient { get; set; }
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		private bool libraryEnabled = false;
		#endregion End Variables

		/// <summary>
		/// Конструктор библиотеки Bitfinex без указания путей в конструкторе
		/// </summary>
		public LibraryBitfinexApi()
		{
		}

		#region IExchangeInterface: Functions
		/// <summary>
		/// Инициализация библиотеки. Используются значения по умолчанию
		/// </summary>
		public void LibraryInit()
		{
			bitfinexClient = new Client("Key", "Secret");

			libraryEnabled = true;
		}
		/// <summary>
		/// Инициализация библиотеки. Используются внешние значения для аргументов
		/// </summary>
		public void LibraryInit(string apiKey, string apiSecret, string apiPath = "")
		{
			bitfinexClient = new Client(apiKey, apiSecret, apiPath);

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
			GetTickerResponse response = bitfinexClient.GetTickers();

			List<TickerInformation> result = new List<TickerInformation>();

			for (int index = 0; index < response.Count; index++)
			{
				GetTickersDetail detail = response[index];

				/*
					0 - SYMBOL,
					1 - BID, 
					2 - BID_SIZE, 
					3 - ASK, 
					4 - ASK_SIZE, 
					5 - DAILY_CHANGE, 
					6 - DAILY_CHANGE_PERC, 
					7 - LAST_PRICE, 
					8 - VOLUME, 
					9 - HIGH, 
					10 - LOW
				*/

				TickerInformation ticker = new TickerInformation()
				{
					Symbol = detail.Symbol,
					Ask = Convert.ToDouble(detail.Ask, CultureInfo.InvariantCulture),
					Bid = Convert.ToDouble(detail.Bid, CultureInfo.InvariantCulture),
					Last = Convert.ToDouble(detail.LastPrice, CultureInfo.InvariantCulture),
					Open = default,
					Low = Convert.ToDouble(detail.Low, CultureInfo.InvariantCulture),
					High = Convert.ToDouble(detail.High, CultureInfo.InvariantCulture),
					Volume = Convert.ToDouble(detail.Volume, CultureInfo.InvariantCulture),
					VolumeQuote = default,
					TimestampOpen = default,
					TimestampClose = default,
					DateTimeOpenOrig = detail.Timestamp.ToString(),
					DateTimeCloseOrig = default
				};

				result.Add(ticker);
			}

			return result;
		}
		public List<TradesPublicInformation> GetTradesPublic(string symbol = "", string sort = "", string by = "", string from = "", string till = "", int limit = -1, int offset = -1)
		{
			return new List<TradesPublicInformation>();
		}
		public OrderbookPublicInformation GetOrderbookPublic(string symbol = "", int limit = -1)
		{
			OrderbookPublicResponse response = bitfinexClient.GetOrderbookPublic(symbol, limit);

			string dt = "";

			if ((response.Asks.Count > 0 && response.Bids.Count == 0) || (response.Asks.Count > 0 && response.Bids.Count > 0)) dt = response.Asks[0].Timestamp;
			else if (response.Asks.Count == 0 && response.Bids.Count > 0) dt = response.Bids[0].Timestamp;
			else dt = Helpers.GetServerTimeTicks(2, new DateTime());

			OrderbookPublicInformation result = new OrderbookPublicInformation()
			{
				Datetime = dt,
				Ask = new List<OrderbookPublicInfoDetail>(),
				Bid = new List<OrderbookPublicInfoDetail>()
			};

			foreach (var index in response.Asks)
			{
				OrderbookPublicInfoDetail detailNew = new OrderbookPublicInfoDetail()
				{
					Price = index.Price,
					Size = index.Amount
				};

				result.Ask.Add(detailNew);
			}
			foreach (var index in response.Bids)
			{
				OrderbookPublicInfoDetail detailNew = new OrderbookPublicInfoDetail()
				{
					Price = index.Price,
					Size = index.Amount
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
 