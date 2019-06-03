using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Hitbtc
{
	[Route("/api/2/public/orderbook/{Symbol}", "GET")]
	public class OrderbookPublic : IReturn<OrderbookPublicResponse>
	{
		public string Symbol { get; set; }
		/// <summary>
		/// Limit of orderbook levels, default 100. Set 0 to view full orderbook levels
		/// </summary>
		[DataMember(Name = "limit")]
		public int Limit { get; set; }
	}
	[DataContract]
	public class OrderbookPublicResponse
	{
		[DataMember(Name = "timestamp")]
		public string Datetime { get; set; }
		[DataMember(Name = "ask")]
		public List<OrderbookPublicDetail> Ask { get; set; }
		[DataMember(Name = "bid")]
		public List<OrderbookPublicDetail> Bid { get; set; }
	}
	[DataContract]
	public class OrderbookPublicDetail
	{
		/// <summary>
		/// Total volume of orders with the specified price
		/// </summary>
		[DataMember(Name = "size")]
		public double Size { get; set; }
		/// <summary>
		/// Price level
		/// </summary>
		[DataMember(Name = "price")]
		public double Price { get; set; }
	}
}
