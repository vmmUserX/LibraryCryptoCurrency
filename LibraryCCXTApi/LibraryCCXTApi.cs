using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace LibraryExchangeInterface
{
	public class LibraryCCXTApi : IExchangeInterface
	{
		#region IExchangeInterface: Variables
		/// <summary>
		/// Системное название библиотеки (DLL)
		/// </summary>
		public string LibraryName { get { return "CCXT".ToLower(); } }
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		public bool LibraryEnabled { get { return libraryEnabled; } }
		#endregion IExchangeInterface: End Variables

		#region Variables
		/// <summary>
		/// Список бирж подключенных через API CCXT
		/// </summary>
		private Dictionary<string, dynamic> ListExchanges { get; set; }
		/// <summary>
		/// Список бирж в самой библиотеке CCXT
		/// </summary>
		private List<string> CCXTListExchanges { get; set; }
		/// <summary>
		/// Проводит работы по выполнению кода сценария
		/// </summary>
		private ScriptEngine engine { get; set; }
		/// <summary>
		/// Пространство имен. Чтобы передать значение в сценарий и из него, потребуется привязать переменную
		/// </summary>
		private ScriptScope scope { get; set; }
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		private bool libraryEnabled = false;
		#endregion End Variables

		/// <summary>
		/// Конструктор библиотеки CCXT без указания путей в конструкторе
		/// </summary>
		public LibraryCCXTApi()
		{
		}

		#region IExchangeInterface: Functions
		/// <summary>
		/// Инициализация библиотеки
		/// </summary>
		public void LibraryInit()
		{
			string pathPython = @"d:\Python27";
			string pathIronPython = @"d:\IronPython 2.7";

			engine = Python.CreateEngine();
			var paths = engine.GetSearchPaths();
			paths.Add(String.Format(@"{0}\Lib\site-packages\", pathPython));
			paths.Add(String.Format(@"{0}\", pathPython));
			paths.Add(String.Format(@"{0}\Lib\", pathIronPython));
			engine.SetSearchPaths(paths);

			scope = engine.CreateScope();
			engine.Execute("import sys", scope);
			engine.Execute("import ccxt", scope);

			// Активируем список бирж для работу через API CCXT
			ListExchanges = new Dictionary<string, dynamic>();
			// Список бирж в самой библиотеке CCXT
			CCXTListExchanges = new List<string>();

			libraryEnabled = true;
		}
		/// <summary>
		/// Инициализация библиотеки. Используются внешние значения для аргументов
		/// </summary>
		public void LibraryInit(string apiKey = default, string apiSecret = default, string apiPath = "")
		{
			LibraryInit();
		}
		/// <summary>
		/// Инициализация библиотеки через соккет
		/// </summary>
		public void LibraryInitSocket() { }

		/// <summary>
		/// Получение списка криптовалют на бирже
		/// </summary>
		/// <returns>Возвращение списка криптовалют на бирже</returns>
		public List<CurrencyInfo> GetListCurrency()
		{
			/*foreach (string exchName in ListExchanges)
			{
				Debug.WriteLine(String.Format("LibraryCCXTApi: GetListCurrency() by {0}", exchName));

				dynamic exc = GetExchageApiCcxtByName(exchName);

				// Описание биржи как словарь
				//IronPython.Runtime.PythonDictionary describe = exc.describe();
				// Получение списка валют
				//IronPython.Runtime.PythonDictionary aaaa = exc.fetch_currencies();

				/*IronPython.Runtime.List lst = new IronPython.Runtime.List();
				//lst.Add("1");
				exc.markets = lst;
				IronPython.Runtime.PythonDictionary pd = exc.currencies;*/

				/*var set_markets = exc.set_markets;
				var res = set_markets(exc.markets, exc.currencies);* /

				//var aaa = engine.Execute("binance.load_markets()", scope);

				IronPython.Runtime.PythonDictionary currencies = exc.currencies;
				var markets = exc.markets;
				var fm = exc.load_markets();* /

				dynamic exchange = engine.Execute(@"ccxt.bittrex()", scope);
				exchange.load_markets();
				//pprint(exchange.symbols)
				var exchange_symbols = exchange.symbols;

				//Debug.WriteLine(String.Format("LibraryCCXTApi: currencies count for {0} = {1}", exchName, exchange_symbols));
				Debug.WriteLine("1");
			}*/

			return new List<CurrencyInfo>();
		}
		/// <summary>
		/// Получение списка пар криптовалют на бирже
		/// </summary>
		/// <returns>Возвращение списка пар криптовалют на бирже</returns>
		public List<SymbolPairsInfo> GetListSymbols()
		{
			return new List<SymbolPairsInfo>();
		}
		/// <summary>
		/// Получение списка баланса криптовалют на бирже
		/// </summary>
		/// <returns>Возвращение списка баланса криптовалют на бирже</returns>
		public List<BalanceCurrency> GetBalanceCurrencies()
		{
			return new List<BalanceCurrency>();
		}
		/// <summary>
		/// Получение списка ордеров на бирже
		/// </summary>
		/// <returns>Возвращение списка ордеров на бирже</returns>
		public List<ActiveOrder> GetActiveOrders()
		{
			return new List<ActiveOrder>();
		}
		public List<TickerInformation> GetTickers()
		{
			return new List<TickerInformation>();
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

		/// <summary>
		/// Получаем доступ к API биржи через CCXT находящейся в списке бирж
		/// </summary>
		/// <param name="exchangeName">Имя биржи</param>
		/// <returns>Возвращает доступ к API биржи через CCXT находящейся в списке бирж</returns>
		private dynamic GetExchageApiCcxtByName(string exchangeName)
		{
			try
			{
				var exchangeSingle = ListExchanges.Single(s => s.Key == exchangeName);
				dynamic exchange = exchangeSingle.Value;

				return exchange;
			}
			catch (Exception exc)
			{
				Debug.WriteLine(exc);

				dynamic exchangeRegistred = RegisterExchengeByName(exchangeName);
				ListExchanges.Add(exchangeName, exchangeRegistred);

				return exchangeRegistred;
			}
		}
		/// <summary>
		/// Регистрация биржи по её имени в библиотеке CCXT
		/// </summary>
		/// <param name="name">Имя биржи</param>
		/// <returns>Возвращает зарегистрованную биржу по её имени в библиотеке CCXT или null, если не была найфдена</returns>
		private dynamic RegisterExchengeByName(string name)
		{
			if (CCXTListExchanges.Count == 0) CCXTFillListExchanges();

			try
			{
				string exchName = CCXTListExchanges.Single(s => s == name);
			}
			catch (Exception)
			{
				return null;
			}

			if (name == "_1broker") Dummy();
			else if (name == "_1btcxe") Dummy();
			else if (name == "acx") Dummy();
			else if (name == "allcoin") Dummy();
			else if (name == "anxpro") Dummy();
			else if (name == "anybits") Dummy();
			else if (name == "bcex") Dummy();
			else if (name == "bibox") Dummy();
			else if (name == "bigone") Dummy();
			#region Binance
			else if (name == "binance")
			{
				dynamic exchange = engine.Execute(@"ccxt.binance({'apiKey': 'Key', 'secret': 'Secret'})", scope);

				return exchange;
			}
			#endregion Binance
			else if (name == "bit2c") Dummy();
			else if (name == "bitbank") Dummy();
			else if (name == "bitbay") Dummy();
			#region Bitfinex
			else if (name == "bitfinex")
			{
				dynamic exchange = engine.Execute(@"ccxt.bitfinex({'apiKey': 'Key', 'secret': 'Secret'})", scope);

				return exchange;
			}
			#endregion End Bitfinex
			else if (name == "bitfinex2") Dummy();
			else if (name == "bitflyer") Dummy();
			else if (name == "bitforex") Dummy();
			else if (name == "bithumb") Dummy();
			else if (name == "bitibu") Dummy();
			else if (name == "bitkk") Dummy();
			else if (name == "bitlish") Dummy();
			else if (name == "bitmarket") Dummy();
			else if (name == "bitmex") Dummy();
			else if (name == "bitsane") Dummy();
			else if (name == "bitso") Dummy();
			else if (name == "bitstamp") Dummy();
			else if (name == "bitstamp1") Dummy();
			else if (name == "bittrex") Dummy();
			else if (name == "bitz") Dummy();
			else if (name == "bl3p") Dummy();
			else if (name == "bleutrade") Dummy();
			else if (name == "braziliex") Dummy();
			else if (name == "btcalpha") Dummy();
			else if (name == "btcbox") Dummy();
			else if (name == "btcchina") Dummy();
			else if (name == "btcexchange") Dummy();
			else if (name == "btcmarkets") Dummy();
			else if (name == "btctradeim") Dummy();
			else if (name == "btctradeua") Dummy();
			else if (name == "btcturk") Dummy();
			else if (name == "btcx") Dummy();
			else if (name == "buda") Dummy();
			else if (name == "bxinth") Dummy();
			else if (name == "ccex") Dummy();
			else if (name == "cex") Dummy();
			else if (name == "chbtc") Dummy();
			else if (name == "chilebit") Dummy();
			else if (name == "cobinhood") Dummy();
			else if (name == "coinbase") Dummy();
			else if (name == "coinbaseprime") Dummy();
			else if (name == "coinbasepro") Dummy();
			else if (name == "coincheck") Dummy();
			else if (name == "coinegg") Dummy();
			else if (name == "coinex") Dummy();
			else if (name == "coinexchange") Dummy();
			else if (name == "coinfalcon") Dummy();
			else if (name == "coinfloor") Dummy();
			else if (name == "coingi") Dummy();
			else if (name == "coinmarketcap") Dummy();
			else if (name == "coinmate") Dummy();
			else if (name == "coinnest") Dummy();
			else if (name == "coinone") Dummy();
			else if (name == "coinsecure") Dummy();
			else if (name == "coinspot") Dummy();
			else if (name == "cointiger") Dummy();
			else if (name == "coolcoin") Dummy();
			else if (name == "crypton") Dummy();
			else if (name == "cryptopia") Dummy();
			else if (name == "deribit") Dummy();
			else if (name == "dsx") Dummy();
			else if (name == "ethfinex") Dummy();
			#region Exmo
			else if (name == "exmo")
			{
				dynamic exchange = engine.Execute(@"ccxt.exmo({'apiKey': 'Key', 'secret': 'Secret'})", scope);

				return exchange;
			}
			#endregion End Exmo
			else if (name == "exx") Dummy();
			else if (name == "fcoin") Dummy();
			else if (name == "flowbtc") Dummy();
			else if (name == "foxbit") Dummy();
			else if (name == "fybse") Dummy();
			else if (name == "fybsg") Dummy();
			else if (name == "gatecoin") Dummy();
			else if (name == "gateio") Dummy();
			else if (name == "gdax") Dummy();
			else if (name == "gemini") Dummy();
			else if (name == "getbtc") Dummy();
			else if (name == "hadax") Dummy();
			#region HitBTC
			else if (name == "hitbtc")
			{
				dynamic exchange = engine.Execute(@"ccxt.hitbtc({'apiKey': 'Key', 'secret': 'Secret'})", scope);

				return exchange;
			}
			#endregion End HitBTC
			else if (name == "hitbtc2") Dummy();
			else if (name == "huobi") Dummy();
			else if (name == "huobicny") Dummy();
			else if (name == "huobipro") Dummy();
			else if (name == "ice3x") Dummy();
			else if (name == "independentreserve") Dummy();
			else if (name == "indodax") Dummy();
			else if (name == "itbit") Dummy();
			else if (name == "jubi") Dummy();
			else if (name == "kraken") Dummy();
			#region KuCoin
			else if (name == "kucoin")
			{
				dynamic exchange = engine.Execute(@"ccxt.kucoin({'apiKey': 'Key', 'secret': 'Secret'})", scope);

				return exchange;
			}
			#endregion End KuCoin
			else if (name == "kuna") Dummy();
			else if (name == "lakebtc") Dummy();
			else if (name == "lbank") Dummy();
			else if (name == "liqui") Dummy();
			else if (name == "liquid") Dummy();
			#region Livecoin
			else if (name == "livecoin")
			{
				dynamic exchange = engine.Execute(@"ccxt.livecoin({'apiKey': 'Key', 'secret': 'Secret'})", scope);

				return exchange;
			}
			#endregion End Livecoin
			else if (name == "luno") Dummy();
			else if (name == "lykke") Dummy();
			else if (name == "mercado") Dummy();
			else if (name == "mixcoins") Dummy();
			else if (name == "negociecoins") Dummy();
			else if (name == "nova") Dummy();
			else if (name == "okcoincny") Dummy();
			else if (name == "okcoinusd") Dummy();
			#region Okex
			else if (name == "okex")
			{
				dynamic exchange = engine.Execute(@"ccxt.okex({'apiKey': 'Key', 'secret': 'Secret'})", scope);

				return exchange;
			}
			#endregion End Okex
			else if (name == "paymium") Dummy();
			else if (name == "poloniex") Dummy();
			else if (name == "qryptos") Dummy();
			else if (name == "quadrigacx") Dummy();
			else if (name == "quoinex") Dummy();
			else if (name == "rightbtc") Dummy();
			else if (name == "southxchange") Dummy();
			else if (name == "surbitcoin") Dummy();
			else if (name == "theocean") Dummy();
			else if (name == "therock") Dummy();
			else if (name == "tidebit") Dummy();
			else if (name == "tidex") Dummy();
			else if (name == "uex") Dummy();
			else if (name == "urdubit") Dummy();
			else if (name == "vaultoro") Dummy();
			else if (name == "vbtc") Dummy();
			else if (name == "virwox") Dummy();
			else if (name == "wex") Dummy();
			else if (name == "xbtce") Dummy();
			#region YoBit
			else if (name == "yobit")
			{
				dynamic exchange = engine.Execute(@"ccxt.yobit({'apiKey': 'Key', 'secret': 'Secret'})", scope);

				return exchange;
			}
			#endregion End YoBit
			else if (name == "yunbi") Dummy();
			else if (name == "zaif") Dummy();
			else if (name == "zb") Dummy();

			return null;
		}
		/// <summary>
		/// Заполнение списка бирж в самой библиотеке CCXT
		/// </summary>
		private void CCXTFillListExchanges()
		{
			dynamic dynListExchanges = engine.Execute("ccxt.exchanges", scope);

			foreach (string name in dynListExchanges)
			{
				//Debug.WriteLine(String.Format("i = {0}", i));

				CCXTListExchanges.Add(name);
			}
		}
		/// <summary>
		/// Функция-пустышка для функции CCXTFillListExchanges
		/// </summary>
		private void Dummy() { }
	}
}