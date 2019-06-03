using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Exmo
{
	[Route("/order_book/", "GET")]
	public class OrderbookPublic : IReturn<OrderbookPublicResponse>
	{
		public string pair { get; set; }
		/// <summary>
		/// Limit of orderbook levels, default 100. Set 0 to view full orderbook levels
		/// </summary>
		[DataMember(Name = "limit")]
		public int Limit { get; set; }
	}
	[DataContract]
	public class OrderbookPublicResponse : Dictionary<string, OrderbookPublicDetail>
	{
	}
	[DataContract]
	public class OrderbookPublicDetail
	{
		[DataMember(Name = "ask_quantity")]
		public double AskQuantity { get; set; }
		[DataMember(Name = "ask_amount")]
		public double AskQmount { get; set; }
		[DataMember(Name = "ask_top")]
		public double AskTop { get; set; }
		[DataMember(Name = "bid_quantity")]
		public double BidQuantity { get; set; }
		[DataMember(Name = "bid_amount")]
		public double BidAmount { get; set; }
		[DataMember(Name = "bid_top")]
		public double BidTop { get; set; }
		[DataMember(Name = "ask")]
		public List<List<string>> Asks { get; set; }
		[DataMember(Name = "bid")]
		public List<List<string>> Bids { get; set; }
	}
}