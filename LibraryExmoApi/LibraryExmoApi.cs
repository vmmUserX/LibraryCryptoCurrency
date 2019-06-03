using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryExchangeInterface.Data.Exmo;

namespace LibraryExchangeInterface
{
	public class LibraryExmoApi : IExchangeInterface
	{
		#region IExchangeInterface: Variables
		/// <summary>
		/// Системное название библиотеки (DLL)
		/// </summary>
		public string LibraryName { get { return "Exmo".ToLower(); } }
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		public bool LibraryEnabled { get { return libraryEnabled; } }
		#endregion IExchangeInterface: End Variables

		#region Variables
		private Client exmoClient { get; set; }
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		private bool libraryEnabled = false;
		#endregion End Variables

		/// <summary>
		/// Конструктор библиотеки Livecoin без указания путей в конструкторе
		/// </summary>
		public LibraryExmoApi()
		{
		}

		#region IExchangeInterface: Functions
		/// <summary>
		/// Инициализация библиотеки. Используются значения по умолчанию
		/// </summary>
		public void LibraryInit()
		{
			exmoClient = new Client("Key", "Secret");

			libraryEnabled = true;
		}
		/// <summary>
		/// Инициализация библиотеки. Используются внешние значения для аргументов
		/// </summary>
		public void LibraryInit(string apiKey, string apiSecret, string apiPath = "")
		{
			exmoClient = new Client(apiKey, apiSecret, apiPath);

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
			//var result = exmoClient.GetListSymbols();

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
			GetTickersResponse response = exmoClient.GetTickers();

			List<TickerInformation> result = new List<TickerInformation>();

			foreach(var ticket in response)
			{
				string key = ticket.Key;
				GetTickersDetail ti = ticket.Value;

				TickerInformation tickerInfo = new TickerInformation()
				{
					Symbol = key,
					Ask = ti.AskPrice,
					Bid = ti.BidPrice,
					Last = ti.Last,
					Open = default,
					Low = ti.Low,
					High = ti.High,
					Volume = ti.Volume,
					VolumeQuote = default,
					TimestampOpen = default,
					TimestampClose = default,
					DateTimeOpenOrig = default,
					DateTimeCloseOrig = default
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
			OrderbookPublicResponse response = exmoClient.GetOrderbookPublic(symbol, limit);

			OrderbookPublicInformation result = new OrderbookPublicInformation()
			{
				Datetime = Helpers.GetServerTimeTicks(1, new DateTime()),
				Ask = new List<OrderbookPublicInfoDetail>(),
				Bid = new List<OrderbookPublicInfoDetail>()
			};

			OrderbookPublicDetail opd = response.FirstOrDefault().Value;

			foreach (var index in opd.Asks)
			{
				OrderbookPublicInfoDetail detailNew = new OrderbookPublicInfoDetail()
				{
					Price = Convert.ToDouble(index[0], CultureInfo.InvariantCulture),
					Size = Convert.ToDouble(index[1], CultureInfo.InvariantCulture)
				};

				result.Ask.Add(detailNew);
			}
			foreach (var index in opd.Bids)
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
