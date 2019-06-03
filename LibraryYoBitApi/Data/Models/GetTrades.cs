using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Yobit
{
	[DataContract]
	public class GetTradesResponse : Dictionary<string, GetTradesObject[]>
	{
	}
	public class GetTradesObject
	{
		/// <summary>
		/// Тип: ask - продажа, bid - покупка
		/// </summary>
		public string type { get; set; }
		/// <summary>
		/// Цена покупки/продажи
		/// </summary>
		public float price { get; set; }
		/// <summary>
		/// Количество
		/// </summary>
		public float amount { get; set; }
		/// <summary>
		/// Идентификатор сделки
		/// </summary>
		public Int64 tid { get; set; }
		/// <summary>
		/// Unix time stamp сделки
		/// </summary>
		public Int64 timestamp { get; set; }
	}
}
