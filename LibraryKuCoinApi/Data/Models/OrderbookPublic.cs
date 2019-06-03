using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.KuCoin
{
	[Route("/v1/open/orders", "GET")]
	public class OrderbookPublic : IReturn<OrderbookPublicResponse>
	{
		public string symbol { get; set; }
		public int limit { get; set; }
	}
	[DataContract]
	public class OrderbookPublicResponse
	{
		[DataMember(Name = "success")]
		public string Success { get; set; }
		[DataMember(Name = "code")]
		public string Code { get; set; }
		[DataMember(Name = "msg")]
		public string Message { get; set; }
		[DataMember(Name = "timestamp")]
		public Int64 TimestampResponse { get; set; }
		[DataMember(Name = "data")]
		public OrderbookPublicDetail Data { get; set; }
	}
	[DataContract]
	public class OrderbookPublicDetail
	{
		[DataMember(Name = "SELL")]
		public List<List<string>> Bids { get; set; }
		[DataMember(Name = "BUY")]
		public List<List<string>> Asks { get; set; }
		[DataMember(Name = "timestamp")]
		public Int64 Timestamp { get; set; }
	}
}