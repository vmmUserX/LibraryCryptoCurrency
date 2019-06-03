using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LibraryExchangeInterface.Data.Hitbtc;
using SuperSocket.ClientEngine;
using WebSocket4Net;

namespace LibraryExchangeInterface
{
	public class LibraryHitBtcApi : IExchangeInterface
	{
		#region IExchangeInterface: Variables
		/// <summary>
		/// Системное название библиотеки (DLL)
		/// </summary>
		public string LibraryName { get { return "HitBTC".ToLower(); } }
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		public bool LibraryEnabled { get { return libraryEnabled; } }
		#endregion IExchangeInterface: End Variables

		#region Variables
		private Client hitbtcClient { get; set; }
		private WebSocket socket;
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		private bool libraryEnabled = false;
		#endregion End Variables

		/// <summary>
		/// Конструктор библиотеки HitBtc без указания путей в конструкторе
		/// </summary>
		public LibraryHitBtcApi()
		{
		}

		#region IExchangeInterface: Functions
		/// <summary>
		/// Инициализация библиотеки. Используются значения по умолчанию
		/// </summary>
		public void LibraryInit()
		{
			
			hitbtcClient = new Client("Key", "Secret");

			libraryEnabled = true;
		}
		/// <summary>
		/// Инициализация библиотеки. Используются внешние значения для аргументов
		/// </summary>
		public void LibraryInit(string apiKey, string apiSecret, string apiPath = "")
		{
			hitbtcClient = new Client(apiKey, apiSecret, apiPath);

			libraryEnabled = true;
		}
		/// <summary>
		/// Инициализация библиотеки через соккет
		/// </summary>
		public void LibraryInitSocket()
		{
			socket = new WebSocket("wss://api.hitbtc.com/api/2/ws", sslProtocols: SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls);
			socket.Opened += this.Socket_Opened;
			socket.MessageReceived += this.Socket_MessageReceived;
			socket.Error += this.Socket_Error;
			socket.Closed += this.Socket_Closed;

			socket.Open();
			//Task.Delay(1000);
			Thread.Sleep(100);
		}

		private void Socket_Opened(object sender, EventArgs e)
		{
			Debug.WriteLine("Socket_Opened " + e.ToString());

			var a = GetListSymbols();
		}
		private void Socket_MessageReceived(object sender, MessageReceivedEventArgs e)
		{
			Debug.WriteLine("Socket_MessageReceived " + e.Message);
		}
		private void Socket_Error(object sender, ErrorEventArgs e)
		{
			Debug.WriteLine("Socket_Error " + e.Exception);
		}
		private void Socket_Closed(object sender, EventArgs e)
		{
			Debug.WriteLine("Socket_Closed");
		}

		public List<CurrencyInfo> GetListCurrency()
		{
			List<CurrenciesResponse> list = hitbtcClient.GetCurrenciesList();

			List<CurrencyInfo> result = new List<CurrencyInfo>();

			foreach (CurrenciesResponse index in list)
			{
				CurrencyInfo currencyInfo = new CurrencyInfo()
				{
					Id = index.Id,
					FullName = index.FullName,
					Crypto = index.Crypto,
					PayinEnabled = index.PayinEnabled,
					PayinPaymentId = index.PayinPaymentId,
					PayinConfirmations = index.PayinConfirmations,
					PayoutEnabled = index.PayoutEnabled,
					PayoutIsPaymentId = index.PayoutIsPaymentId,
					TransferEnabled = index.TransferEnabled,
					Delisted = index.Delisted,
					PayoutFee = index.PayoutFee
				};
				result.Add(currencyInfo);
			}

			return result;
		}
		public List<SymbolPairsInfo> GetListSymbols()
		{
			List<SymbolPairsInfo> result = new List<SymbolPairsInfo>();

			if (hitbtcClient != null)
			{
				List<SymbolsResponse> symbols = hitbtcClient.GetSymbolsList();

				foreach (SymbolsResponse index in symbols)
				{
					CultureInfo cultureInfo = CultureInfo.InvariantCulture;
					string str = index.TickSize.ToString("0.############", cultureInfo);
					string[] strArray = str.Split('.');

					result.Add(new SymbolPairsInfo()
					{
						Name = index.Id,
						LimitNumberDecimalPlaces = strArray[1].Length,
						TickSize = index.TickSize
					});
				}
			}
			else if (socket != null)
			{
				this.socket.Send("{\"method\": \"getSymbols\"}");
			}

			return result;
		}
		public List<BalanceCurrency> GetBalanceCurrencies()
		{
			List<BalanceCurrencyDetail> balanceCurrencies = hitbtcClient.GetBalanceCurrency();

			List<BalanceCurrency> result = new List<BalanceCurrency>();

			foreach (BalanceCurrencyDetail index in balanceCurrencies)
			{
				result.Add(new BalanceCurrency()
				{
					Currency = index.Currency, Available = index.Available, Reserved = index.Reserved, AvailableWithdrawal = index.Available, Total = index.Available + index.Reserved
				});
			}

			return result;
		}
		public List<ActiveOrder> GetActiveOrders()
		{
			ActiveOrdersResponse response = hitbtcClient.GetActiveOrders();

			List<ActiveOrder> result = new List<ActiveOrder>();

			foreach (ActiveOrdersDetail ao in response)
			{
				ActiveOrder activeOrder = new ActiveOrder()
				{
					Id = ao.Id,
					ClientOrderId = ao.ClientOrderId,
					Symbol = ao.Symbol,
					Side = ao.Side,
					Status = ao.Status,
					TypeOrder = ao.TypeOrder,
					TimeInForce = ao.TypeOrder,
					Quantity = ao.Quantity,
					Price = ao.Price,
					CumQuantity = ao.CumQuantity,
					CreatedAt = ao.CreatedAt,
					UpdatedAt = ao.UpdatedAt
				};

				result.Add(activeOrder);
			}

			return result;
		}
		public List<TickerInformation> GetTickers()
		{
			TickerInfoResponse response = hitbtcClient.GetTickers();

			List<TickerInformation> result = new List<TickerInformation>();

			foreach (TickerInfoDetail ti in response)
			{
				DateTime parsedDate = DateTime.Parse(ti.Timestamp);
				string str = Helpers.GetServerTimeTicks((int)DateTicksType.Epoch, parsedDate);
				Int64 timestamp = Convert.ToInt64(str)/* + parsedDate.Millisecond*/;
				//Int64 timestamp = Convert.ToInt64(str);

				//Debug.WriteLine(String.Format("originalDate = {0} parsedDate = {1} timestamp = {2}", ti.Timestamp, parsedDate, timestamp));

				TickerInformation tickerInfo = new TickerInformation()
				{
					Ask = ti.Ask,
					Bid = ti.Bid,
					Last = ti.Last,
					Open = ti.Open,
					Low = ti.Low,
					High = ti.High,
					Volume = ti.Volume,
					VolumeQuote = ti.VolumeQuote,
					TimestampOpen = timestamp,
					DateTimeOpenOrig = ti.Timestamp,
					TimestampClose = timestamp,
					DateTimeCloseOrig = ti.Timestamp,
					Symbol = ti.Symbol
				};

				result.Add(tickerInfo);
			}

			return result;
		}
		public List<TradesPublicInformation> GetTradesPublic(string symbol = "", string sort = "", string by = "", string from = "", string till = "", int limit = -1, int offset = -1)
		{
			TradesPublicResponse response = hitbtcClient.GetTradesPublic(symbol, sort, by, from, till, limit, offset);

			List<TradesPublicInformation> result = new List<TradesPublicInformation>();

			foreach(TradesPublicDetail trades in response)
			{
				TradesPublicInformation info = new TradesPublicInformation()
				{
					Id = trades.Id,
					Price = trades.Price,
					Quantity = trades.Quantity,
					Side = trades.Side,
					Timestamp = trades.Timestamp
				};

				result.Add(info);
			}

			return result;
		}
		public OrderbookPublicInformation GetOrderbookPublic(string symbol = "", int limit = -1)
		{
			OrderbookPublicResponse response = hitbtcClient.GetOrderbookPublic(symbol, limit);

			OrderbookPublicInformation result = new OrderbookPublicInformation()
			{
				Datetime = response.Datetime,
				Ask = new List<OrderbookPublicInfoDetail>(),
				Bid = new List<OrderbookPublicInfoDetail>()
			};

			foreach(var index in response.Ask)
			{
				OrderbookPublicInfoDetail detailNew = new OrderbookPublicInfoDetail()
				{
					Price = index.Price,
					Size = index.Size
				};

				result.Ask.Add(detailNew);
			}
			foreach (var index in response.Bid)
			{
				OrderbookPublicInfoDetail detailNew = new OrderbookPublicInfoDetail()
				{
					Price = index.Price,
					Size = index.Size
				};

				result.Bid.Add(detailNew);
			}

			return result;
		}
		public OrderInformation CreateNewOrder(string symbol, string side, double quantity, double price = -1, double stopPrice = -1,
				string timeInForce = "Day", DateTime expireTime = default, string clientOrderId = null, bool strictValidate = true)
		{
			NewOrderResponse response = hitbtcClient.CreateNewOrder(symbol, side, quantity, price, stopPrice, timeInForce, expireTime, clientOrderId, strictValidate);

			OrderInformation result = new OrderInformation()
			{
				Id = response.Id,
				ClientOrderId = response.ClientOrderId,
				Symbol = response.Symbol,
				Side = response.Side,
				Status = response.Status,
				TypeOrder = response.TypeOrder,
				TimeInForce = response.TimeInForce,
				Quantity = response.Quantity,
				Price = response.Price,
				CumQuantity = response.CumQuantity,
				CreatedAt = response.CreatedAt,
				UpdatedAt = response.UpdatedAt
			};

			return result;
		}
		/// <summary>
		/// Cancel all active orders, or all active orders for specified symbol
		/// </summary>
		/// <param name="symbol">Optional parameter to filter active orders by symbol</param>
		public List<OrderInformation> SetCancelOrders(string symbol = "")
		{
			CancelOrdersResponse response = hitbtcClient.SetCancelOrders(symbol);

			List<OrderInformation> result = new List<OrderInformation>();

			foreach (CancelOrderResponse orderResp in response)
			{
				OrderInformation order = new OrderInformation()
				{
					Id = orderResp.Id,
					ClientOrderId = orderResp.ClientOrderId,
					Symbol = orderResp.Symbol,
					Side = orderResp.Side,
					Status = orderResp.Status,
					TypeOrder = orderResp.TypeOrder,
					TimeInForce = orderResp.TimeInForce,
					Quantity = orderResp.Quantity,
					Price = orderResp.Price,
					CumQuantity = orderResp.CumQuantity,
					CreatedAt = orderResp.CreatedAt,
					UpdatedAt = orderResp.UpdatedAt
				};

				result.Add(order);
			}

			return result;
		}
		/// <summary>
		/// Cancel order for specified symbol by clientOrderId
		/// </summary>
		/// <param name="symbol">Optional parameter to filter active orders by symbol</param>
		public OrderInformation SetCancelOrder(string clientOrderId, string symbol = "")
		{
			CancelOrderResponse response = hitbtcClient.SetCancelOrder(clientOrderId, symbol);

			OrderInformation result = new OrderInformation()
			{
				Id = response.Id,
				ClientOrderId = response.ClientOrderId,
				Symbol = response.Symbol,
				Side = response.Side,
				Status = response.Status,
				TypeOrder = response.TypeOrder,
				TimeInForce = response.TimeInForce,
				Quantity = response.Quantity,
				Price = response.Price,
				CumQuantity = response.CumQuantity,
				CreatedAt = response.CreatedAt,
				UpdatedAt = response.UpdatedAt
			};

			return result;
		}
		#endregion IExchangeInterface: End Functions
	}
}