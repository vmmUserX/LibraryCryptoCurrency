using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Yobit
{
	public class YobitTradeApiResponse
	{
		public int success { get; set; }
		public string error { get; set; }
	}
	public enum TradeOperationType
	{
		Buy,
		Sell
	}
	[DataContract]
	public class TradeResponse : YobitTradeApiResponse
	{
		public Return @return { get; set; }
	}

	public class Return
	{
		/// <summary>
		/// сколько валюты куплено/продано
		/// </summary>
		public float received { get; set; }
		/// <summary>
		/// сколько валюты осталось купить/продать
		/// </summary>
		public int remains { get; set; }
		/// <summary>
		/// ID созданного ордера
		/// </summary>
		public int order_id { get; set; }
		/// <summary>
		/// балансы, актуальные после запроса
		/// </summary>
		public Funds funds { get; set; }
	}

	public class Funds : Dictionary<string, float>
	{
	}
}
