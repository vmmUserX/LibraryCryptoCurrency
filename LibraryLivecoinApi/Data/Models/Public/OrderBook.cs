using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	[Route("/exchange/order_book", "GET")]
	public class OrderBook : IReturn<OrderBookResponse>
	{
		public string currencyPair { get; set; }
		public string groupByPrice { get; set; }
		public string depth { get; set; }
	}
	[Route("/exchange/all/order_book")]
	public class OrderBookList : IReturn<OrderBookListResponse>
	{
		public string groupByPrice { get; set; }
		public string depth { get; set; }
	}
	[DataContract]
	public class OrderBookResponse
	{
		/*[JsonIgnore]
		public string PairName { get; set; }*/
		[DataMember(Name = "timestamp")]
		public long Timestamp { get; set; }
		[DataMember(Name = "asks")]
		public List<string[]> Asks { get; set; }
		[DataMember(Name = "bids")]
		public List<string[]> Bids { get; set; }
	}
	[DataContract]
	public class OrderBookListResponse : Dictionary<string, OrderBookResponse>
	{

	}
}