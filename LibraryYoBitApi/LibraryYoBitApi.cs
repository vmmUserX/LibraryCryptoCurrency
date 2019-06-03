using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryExchangeInterface.Data.Yobit;

namespace LibraryExchangeInterface
{
	public class LibraryYoBitApi : IExchangeInterface
	{
		#region IExchangeInterface: Variables
		/// <summary>
		/// Системное название библиотеки (DLL)
		/// </summary>
		public string LibraryName { get { return "YoBIT".ToLower(); } }
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		public bool LibraryEnabled { get { return libraryEnabled; } }
		#endregion IExchangeInterface: End Variables

		#region Variables
		private Client yobitClient { get; set; }
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		private bool libraryEnabled = false;
		#endregion End Variables

		/// <summary>
		/// Конструктор библиотеки YoBIT без указания путей в конструкторе
		/// </summary>
		public LibraryYoBitApi()
		{
		}

		#region IExchangeInterface: Functions
		/// <summary>
		/// Инициализация библиотеки. Используются значения по умолчанию
		/// </summary>
		public void LibraryInit()
		{
			yobitClient = new Client("Key", "Secret");

			libraryEnabled = true;
		}
		/// <summary>
		/// Инициализация библиотеки. Используются внешние значения для аргументов
		/// </summary>
		public void LibraryInit(string apiKey, string apiSecret, string apiPath = "")
		{
			yobitClient = new Client(apiKey, apiSecret, apiPath);

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
			List<SymbolPairsInfo> result = new List<SymbolPairsInfo>();

			GetInfoResponse info = yobitClient.Info();
			foreach (var pair in info.pairs)
			{
				string pairName = pair.Key;
				PairInfo pairInfo = pair.Value;

				result.Add(new SymbolPairsInfo { Name = pairName, LimitNumberDecimalPlaces = pairInfo.decimal_places });
			}

			return result;
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
			GetTickerResponse response = yobitClient.GetTickers();

			List<TickerInformation> result = new List<TickerInformation>();

			foreach(var pairInfo in response)
			{
				var key = pairInfo.Key;
				var val = pairInfo.Value;

				Debug.WriteLine(String.Format("{0} {1}", key, val));
			}

			return result;
		}
		public List<TradesPublicInformation> GetTradesPublic(string symbol = "", string sort = "", string by = "", string from = "", string till = "", int limit = -1, int offset = -1)
		{
			return new List<TradesPublicInformation>();
		}
		public OrderbookPublicInformation GetOrderbookPublic(string symbol = "", int limit = -1)
		{
			return new OrderbookPublicInformation();
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