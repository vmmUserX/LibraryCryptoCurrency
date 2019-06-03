using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface
{
	/// <summary>
	/// Класс представляющий один набор бирж
	/// </summary>
	public class ExchangesSet
	{
		/// <summary>
		/// Название набора. На английском и маленькими буквами, для использования в ключах словаря
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Описание набора. Может быть на любом языке, как подсказка
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// Список бирж для набора
		/// </summary>
		public List<IExchangeInterface> ListExchanges { get; set; }

		/// <summary>
		/// Конструктор набора бирж
		/// </summary>
		/// <param name="name">Название набора. На английском и маленькими буквами, для использования в ключах словаря</param>
		/// <param name="description">Описание набора. Может быть на любом языке, как подсказка</param>
		public ExchangesSet(string name, string description)
		{
			Name = name;
			Description = description;
			ListExchanges = new List<IExchangeInterface>();
		}

		/// <summary>
		/// Добавление биржи в список
		/// </summary>
		/// <param name="exchange"></param>
		public void AddExchangeToSet(IExchangeInterface exchange)
		{
			// Аргумент функции не должен иметь значение null, иначе заканчиваем работу функции
			if (exchange == null) return;

			// Проверяем на наличие в списке данной биржи по её имени.
			// Если поиск закончился ошибкой, то в списке данная бирже не обнаружена, значит биржу можно добавлять в список
			if (ListExchanges.Count == 0) ListExchanges.Add(exchange);
			else
			{
				IExchangeInterface tmpExchange = ListExchanges.Select(x => x).Where(x=>x.LibraryName == exchange.LibraryName).FirstOrDefault();
				if (tmpExchange == null) ListExchanges.Add(exchange);
			}
		}
		/// <summary>
		/// Получение словаря со списком символов всех бирж в наборе, где:
		/// Key - название биржи (LibraryName),
		/// Value - список символов для биржи
		/// </summary>
		/// <returns>Возвращение словаря со списком символьных пар бирж</returns>
		public Dictionary<string, List<CurrencyInfo>> GetListCurrency()
		{
			Dictionary<string, List<CurrencyInfo>> result = new Dictionary<string, List<CurrencyInfo>>();

			for (int index=0; index<ListExchanges.Count; index++)
			{
				IExchangeInterface exch = ListExchanges[index];
				List<CurrencyInfo> listCurrencys = exch.GetListCurrency();

				result.Add(exch.LibraryName, listCurrencys);
			}

			return result;
		}
		/// <summary>
		/// Получение словаря со списком символов указанных бирж, где:
		/// Key - название биржи (LibraryName),
		/// Value - список символов для биржи
		/// </summary>
		/// <param name="exchangeName">Список бирж, для которых надо получить список символьных пар</param>
		/// <returns>Возвращение словаря со списком символьных пар бирж</returns>
		public Dictionary<string, List<CurrencyInfo>> GetListCurrency(List<string> exchangesName)
		{
			Dictionary<string, List<CurrencyInfo>> result = new Dictionary<string, List<CurrencyInfo>>();

			for (int index = 0; index < ListExchanges.Count; index++)
			{
				IExchangeInterface exch = ListExchanges[index];
				//List<string> listCurrencys = exch.GetListCurrency(exchangesName);
				//var a = exch.GetListCurrency(exchangesName);

				/*result.Add(exch.LibraryName, listCurrencys);*/
			}

			return result;
		}
		/// <summary>
		/// Получение словаря со списком символьных пар всех бирж в наборе, где:
		/// Key - название биржи (LibraryName),
		/// Value - список символьных пар для биржи
		/// </summary>
		/// <returns>Возвращение словаря со списком символьных пар бирж</returns>
		public Dictionary<string, List<SymbolPairsInfo>> GetListSymbols()
		{
			Dictionary<string, List<SymbolPairsInfo>> result = new Dictionary<string, List<SymbolPairsInfo>>();

			for (int index = 0; index < ListExchanges.Count; index++)
			{
				IExchangeInterface exch = ListExchanges[index];
				List<SymbolPairsInfo> listCurrencys = exch.GetListSymbols();

				result.Add(exch.LibraryName, listCurrencys);
			}

			return result;
		}
		/// <summary>
		/// Получение словаря со списком символьных пар указанных бирж, где:
		/// Key - название биржи (LibraryName),
		/// Value - список символьных пар для биржи
		/// </summary>
		/// <param name="exchangeName">Список бирж, для которых надо получить список символьных пар</param>
		/// <returns>Возвращение словаря со списком символьных пар бирж</returns>
		public Dictionary<string, List<SymbolPairsInfo>> GetListSymbols(List<string> exchangesName)
		{
			Dictionary<string, List<SymbolPairsInfo>> result = new Dictionary<string, List<SymbolPairsInfo>>();

			for (int index = 0; index < ListExchanges.Count; index++)
			{
				IExchangeInterface exch = ListExchanges[index];
				//List<string> listCurrencys = exch.GetListCurrency(exchangesName);
				//var a = exch.GetListSymbols(exchangesName);

				/*result.Add(exch.LibraryName, listCurrencys);*/
			}

			return result;
		}
		/// <summary>
		/// Получение словаря со списком баланса символов указанных бирж, где:
		/// Key - название биржи (LibraryName),
		/// Value - список баланса символов для биржи
		/// </summary>
		/// <returns>Возвращение словаря со списком баланса символов бирж</returns>
		public Dictionary<string, List<BalanceCurrency>> GetListBalanceCurrency()
		{
			Dictionary<string, List<BalanceCurrency>> result = new Dictionary<string, List<BalanceCurrency>>();

			for (int index = 0; index < ListExchanges.Count; index++)
			{
				IExchangeInterface exch = ListExchanges[index];
				List<BalanceCurrency> listCurrencys = exch.GetBalanceCurrencies();

				result.Add(exch.LibraryName, listCurrencys);
			}

			return result;
		}
		/// <summary>
		/// Получение словаря со списком активных ордеров указанных бирж, где:
		/// Key - название биржи (LibraryName),
		/// Value - список активных ордеров для биржи
		/// </summary>
		/// <returns>Возвращение словаря со списком активных ордеров бирж</returns>
		public Dictionary<string, List<ActiveOrder>> GetListActiveOrders()
		{
			Dictionary<string, List<ActiveOrder>> result = new Dictionary<string, List<ActiveOrder>>();

			for (int index = 0; index < ListExchanges.Count; index++)
			{
				IExchangeInterface exch = ListExchanges[index];
				List<ActiveOrder> listActiveOrders = exch.GetActiveOrders();

				result.Add(exch.LibraryName, listActiveOrders);
			}

			return result;
		}
		public Dictionary<string, List<TickerInformation>> GetTickers()
		{
			Dictionary<string, List<TickerInformation>> result = new Dictionary<string, List<TickerInformation>>();

			for (int index = 0; index < ListExchanges.Count; index++)
			{
				IExchangeInterface exch = ListExchanges[index];

				if (exch.LibraryName != "yobit" && exch.LibraryName != "bitfinex")
				{
					List<TickerInformation> listTickers = exch.GetTickers();

					result.Add(exch.LibraryName, listTickers);
				}
			}

			return result;
		}
	}
}