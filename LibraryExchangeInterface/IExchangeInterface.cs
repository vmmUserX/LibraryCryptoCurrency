// ==<vmm>==
// 
// Files of Library of Crypto Currency Market:
// IExchangeInterface.cs
// Descriptions: Developer for cryptocurrency market on C#
// ==-   -==
// SBT
//
// ======================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface
{
	public interface IExchangeInterface
	{
		/// <summary>
		/// Системное название библиотеки (DLL)
		/// </summary>
		string LibraryName { get; }
		/// <summary>
		/// Состояние работы библиотеки
		/// </summary>
		bool LibraryEnabled { get; }
		/// <summary>
		/// Инициализация библиотеки, со значениями по умолчанию
		/// </summary>
		void LibraryInit();
		/// <summary>
		/// Инициализация библиотеки, с внешними аргументами
		/// </summary>
		void LibraryInit(string apiKey, string apiSecret, string apiPath = "");
		/// <summary>
		/// Инициализация библиотеки через соккет
		/// </summary>
		void LibraryInitSocket();
		/// <summary>
		/// Получение списка криптовалют на бирже
		/// </summary>
		/// <returns>Возвращение списка криптовалют на бирже</returns>
		List<CurrencyInfo> GetListCurrency();
		/// <summary>
		/// Получение списка пар криптовалют на бирже
		/// </summary>
		/// <returns>Возвращение списка пар криптовалют на бирже</returns>
		List<SymbolPairsInfo> GetListSymbols();
		/// <summary>
		/// Получение списка баланса криптовалют на бирже
		/// </summary>
		/// <returns>Возвращение списка баланса криптовалют на бирже</returns>
		List<BalanceCurrency> GetBalanceCurrencies();
		/// <summary>
		/// Получение списка ордеров на бирже
		/// </summary>
		/// <returns>Возвращение списка ордеров на бирже</returns>
		List<ActiveOrder> GetActiveOrders();
		/// <summary>
		/// Получение списка тикеров на бирже
		/// </summary>
		/// <returns>Возвращение списка тикеров на бирже</returns>
		List<TickerInformation> GetTickers();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		List<TradesPublicInformation> GetTradesPublic(string symbol = "", string sort = "", string by = "", string from = "", string till = "", int limit = -1, int offset = -1);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		OrderbookPublicInformation GetOrderbookPublic(string symbol = "", int limit = -1);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="clientOrderId"></param>
		/// <returns></returns>
		OrderInformation CreateNewOrder(string symbol, string side, double quantity, double price = -1, double stopPrice = -1,
				string timeInForce = "Day", DateTime expireTime = default, string clientOrderId = null, bool strictValidate = true);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		List<OrderInformation> SetCancelOrders(string symbol = "");
		/// <summary>
		/// 
		/// </summary>
		/// <param name="clientOrderId"></param>
		/// <param name="symbol"></param>
		/// <returns></returns>
		OrderInformation SetCancelOrder(string clientOrderId, string symbol = "");
	}
}