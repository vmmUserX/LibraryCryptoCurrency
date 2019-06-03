using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	[Route("/exchange/last_trades", "GET")]
	public class LastTrades : IReturn<LastTradesResponse>
	{
		public string currencyPair { get; set; }
		public string minutesOrHour { get; set; }
		public string type { get; set; }
	}
	[DataContract]
	public class LastTradesResponse : List<LastTrade>
	{
	}
	[DataContract]
	public class LastTrade
	{
		/*[DataMember]
		public string PairName { get; set; }*/
		[DataMember(Name = "time")]
		public long Time { get; set; }
		[DataMember(Name = "id")]
		public int Id { get; set; }
		[DataMember(Name = "price")]
		public decimal Price { get; set; }
		[DataMember(Name = "quantity")]
		public decimal Quantity { get; set; }
		[DataMember(Name = "type")]
		public TradeType Type { get; set; }
	}
}