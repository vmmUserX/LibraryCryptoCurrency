using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Okex
{
	[Route("/api/spot/v3/instruments/{Symbol}/book", "GET")]
	public class OrderbookPublic : IReturn<OrderbookPublicResponse>
	{
		public string Symbol { get; set; }
		public int size { get; set; }
	}
	[DataContract]
	public class OrderbookPublicResponse
	{
		[DataMember(Name = "timestamp")]
		public string Timestamp { get; set; }
		[DataMember(Name = "asks")]
		public List<List<string>> Asks { get; set; }
		[DataMember(Name = "bids")]
		public List<List<string>> Bids { get; set; }
	}
}
