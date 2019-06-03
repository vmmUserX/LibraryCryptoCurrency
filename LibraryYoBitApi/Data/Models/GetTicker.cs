using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Yobit
{
	/**
	 * Класс запроса
	 */
	[Route("/ticker")]
	public class GetTicker : IReturn<GetTickerResponse>
	{
	}
	/**
	 * Класс ответа
	 */
	[DataContract]
	public class GetTickerResponse : Dictionary<string, PairInfoTicker>
	{
	}
	public class PairInfoTicker
	{
		/// <summary>
		/// макcимальная цена
		/// </summary>
		public float high { get; set; }
		/// <summary>
		/// минимальная цена
		/// </summary>
		public float low { get; set; }
		/// <summary>
		/// средняя цена
		/// </summary>
		public float avg { get; set; }
		/// <summary>
		/// объем торгов
		/// </summary>
		public float vol { get; set; }
		/// <summary>
		/// объем торгов в валюте
		/// </summary>
		public float vol_cur { get; set; }
		/// <summary>
		/// цена последней сделки
		/// </summary>
		public float last { get; set; }
		/// <summary>
		/// цена покупки
		/// </summary>
		public float buy { get; set; }
		/// <summary>
		/// цена продажи
		/// </summary>
		public float sell { get; set; }
		/// <summary>
		/// последнее обновление кэша
		/// </summary>
		public int updated { get; set; }
	}
}
