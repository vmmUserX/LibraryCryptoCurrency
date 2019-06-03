using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibraryExchangeInterface;

namespace Exhanges
{
	public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		/// <summary>
		/// Получаем список валютных пар из всех бирж
		/// </summary>
		List<IExchangeInterface> exchangesList { get; set; }
		IExchangeInterface CurrentExchange { get; set; }

		private delegate void MyEventHandler(OrderbookPublicInformation data);
		List<OrderbookPublicInformation> lstOrderbookPublicInformation = new List<OrderbookPublicInformation>();

		MyEventHandler a1 { get; set; }
		MyEventHandler a2 { get; set; }

		public MainForm()
		{
			InitializeComponent();

			a1 = new MyEventHandler(AnalysOPI1);
			a2 = new MyEventHandler(AnalysOPI2);

			// Создаем один набор бирж для последующей работы с ними
			ExchangesSet exchangesSet = new ExchangesSet("set1", "Тестовый набор бирж");

			// Подключаем библиотеку для взаимодействия с API бирж
			ExchangeInterface exchange = new ExchangeInterface();

			IExchangeInterface ccxt = null;
			// Если подключенных плагинов больше 0, то отображаем подключение для одной биржи CCXT
			if (exchange.ExchangesCount > 0)
			{
				// Получаем конкретную биржу по её имени CCXT
				/*ccxt = exchange.GetExchangeByName("ccxT");
				if (ccxt != null)
				{
					Debug.WriteLine(String.Format("Активировали плагин биржи по имени - {0}", ccxt.LibraryName));

					// Добавляем биржу в набор
					exchangesSet.AddExchangeToSet(ccxt);

					// Вызываем функцию из интерфейса для каждой биржи (если не используется CCXT)
					//exchangesSet.GetListCurrency();
					// Вызываем функцию из интерфейса для каждой биржи (если используется CCXT)
					exchangesSet.GetListCurrency(new List<string> {"binance", "hitbtc", "yobit"});
				}*/

				// Получаем список валютных пар из всех бирж
				exchangesList = exchange.GetExchangesList();
				// Добавляем биржу в набор, исключаяя CCXT
				foreach (IExchangeInterface excs in exchangesList) 
				{
					if (excs.LibraryName != "ccxt" && excs.LibraryName != "yobit")
					{
						exchangesSet.AddExchangeToSet(excs);
						if (excs.LibraryEnabled == false)
						{
							/*if (excs.LibraryName != "hitbtc")*/ excs.LibraryInit();
							//else excs.LibraryInitSocket();
						}
					}
				}
				// Вызываем функцию из интерфейса для каждой биржи в наборе для получения списка символьных пар
				//Dictionary<string, List<SymbolPairsInfo>> listCurrencys = exchangesSet.GetListSymbols();
				// Получаем список по доступным остаткам криптовалют
				/*Dictionary<string, List<BalanceCurrency>> listBalanceCurrency = exchangesSet.GetListBalanceCurrency();
				// Получаем список активных ордеров
				Dictionary<string, List<ActiveOrder>> listActiveOrders = exchangesSet.GetListActiveOrders();
				// Получаем список тикеров
				Dictionary<string, List<TickerInformation>> listTickers = exchangesSet.GetTickers();*/

				//Debug.WriteLine(listTickers);

				/*CurrentExchange = GetExchangeByName("hitbtc");
				if (CurrentExchange != null)
				{
					//List<SymbolPairsInfo> pairsInfos = CurrentExchange.GetListSymbols();

					/*List<CurrencyInfo> exchHitBtcCurrencies = CurrentExchange.GetListCurrency();

					string fee = "";

					CurrencyInfo ci = exchHitBtcCurrencies.Where(x => x.Id.ToLower() == "btc").FirstOrDefault();
					if (ci != null) fee = Helpers.ConvertDoubleToString(ci.PayoutFee);* /

					List<TradesPublicInformation> tradesPublic = CurrentExchange.GetTradesPublic("BTCUSD", "ASC");
					OrderbookPublicInformation orderbookPublic = CurrentExchange.GetOrderbookPublic("BTCUSD", 4);
					List<TickerInformation> tickerInformation = CurrentExchange.GetTickers();
					OrderInformation orderNew = CurrentExchange.CreateNewOrder("BTCUSD", "buy", 0.001d);
					List<OrderInformation> ordersCancel = CurrentExchange.SetCancelOrders("BTCUSD");

					Debug.WriteLine(orderbookPublic);

					a1.BeginInvoke(orderbookPublic, null, null);
					lstOrderbookPublicInformation.Add(orderbookPublic);
				}
				/*IExchangeInterface bfCurrentExchange = GetExchangeByName("yobit");
				if (bfCurrentExchange != null)
				{
					List<TickerInformation> tickerInformation = bfCurrentExchange.GetTickers();

					Debug.WriteLine(tickerInformation);
				}*/

				CurrentExchange = GetExchangeByName("kucoin");
				if (CurrentExchange != null)
				{
					var obitfinex = CurrentExchange.GetOrderbookPublic("BTC-USDT", 20);
					var tbitfinex = CurrentExchange.GetTickers();

					Debug.WriteLine(obitfinex);
				}
			}
		}
		/// <summary>
		/// Получить интерфейс биржи по ее имени
		/// </summary>
		/// <param name="name"></param>
		/// <returns>Возвращает интерфейс биржи по ее имени</returns>
		private IExchangeInterface GetExchangeByName(string name)
		{
			IExchangeInterface exchange = exchangesList.Where(x => x.LibraryName == name).FirstOrDefault();

			return exchange;
		}
		private void AnalysOPI1(OrderbookPublicInformation data)
		{
			if (data != null)
			{
				OrderbookPublicInformation orderbookPublic = CurrentExchange.GetOrderbookPublic("USD", 4);
				a2.BeginInvoke(orderbookPublic, null, null);
				lstOrderbookPublicInformation.Add(orderbookPublic);
			}
		}
		private void AnalysOPI2(OrderbookPublicInformation data)
		{
			if (data != null)
			{
				OrderbookPublicInformation orderbookPublic = CurrentExchange.GetOrderbookPublic("BTCUSD", 4);
				lstOrderbookPublicInformation.Add(orderbookPublic);

				Debug.WriteLine(lstOrderbookPublicInformation.Count);
			}
		}
	}
}