using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	[Route("/exchange/trades")]
	public class LastUserTrades : IReturn<LastUserTradesResponse>
	{
		public string currencyPair { get; set; }
		public string orderDesc { get; set; }
		public string limit { get; set; }
		public string offset { get; set; }
	}
	[DataContract]
	public class LastUserTradesResponse
	{
		[DataMember(Name = "datetime")]
		public long Datetime { get; set; }
		[DataMember(Name = "id")]
		public long Id { get; set; }
		[DataMember(Name = "type")]
		public string PurpleType { get; set; }
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
		[DataMember(Name = "price")]
		public long Price { get; set; }
		[DataMember(Name = "quantity")]
		public double Quantity { get; set; }
		[DataMember(Name = "commission")]
		public double Commission { get; set; }
		[DataMember(Name = "clientorderid")]
		public long Clientorderid { get; set; }
	}
}