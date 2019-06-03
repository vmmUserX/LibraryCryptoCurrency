using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Bitfinex
{
	[Route("/book/{Symbols}", "GET")]
	public class OrderbookPublic : IReturn<OrderbookPublicResponse>
	{
		[DataMember(Name = "symbols")]
		public string Symbols { get; set; }
		[DataMember(Name = "limit_bids")]
		public int LimitBids { get; set; }
		[DataMember(Name = "limit_asks")]
		public int LimitAsks { get; set; }
	}
	[DataContract]
	public class OrderbookPublicResponse
	{
		[DataMember(Name = "bids")]
		public List<OrderbookPublicDetail> Bids { get; set; }
		[DataMember(Name = "asks")]
		public List<OrderbookPublicDetail> Asks { get; set; }
	}
	[DataContract]
	public class OrderbookPublicDetail
	{
		[DataMember(Name = "price")]
		public double Price { get; set; }
		[DataMember(Name = "amount")]
		public double Amount { get; set; }
		[DataMember(Name = "timestamp")]
		public string Timestamp { get; set; }
	}
}
 