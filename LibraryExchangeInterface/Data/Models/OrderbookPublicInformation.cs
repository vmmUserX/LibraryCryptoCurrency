using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface
{
	[DataContract]
	public class OrderbookPublicInformation
	{
		[DataMember(Name = "timestamp")]
		public string Datetime { get; set; }
		[DataMember(Name = "ask")]
		public List<OrderbookPublicInfoDetail> Ask { get; set; }
		[DataMember(Name = "bid")]
		public List<OrderbookPublicInfoDetail> Bid { get; set; }
	}
	[DataContract]
	public class OrderbookPublicInfoDetail
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
