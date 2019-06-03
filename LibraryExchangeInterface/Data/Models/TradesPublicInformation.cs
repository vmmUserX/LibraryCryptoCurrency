using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface
{
	[DataContract]
	public class TradesPublicInformation
	{
		/// <summary>
		/// Trade id
		/// </summary>
		[DataMember(Name = "id")]
		public int Id { get; set; }
		/// <summary>
		/// Trade price
		/// </summary>
		[DataMember(Name = "price")]
		public double Price { get; set; }
		/// <summary>
		/// Trade quantity
		/// </summary>
		[DataMember(Name = "quantity")]
		public double Quantity { get; set; }
		/// <summary>
		/// Trade side sell or buy
		/// </summary>
		[DataMember(Name = "side")]
		public string Side { get; set; }
		/// <summary>
		/// Datetime Trade timestamp
		/// </summary>
		[DataMember(Name = "timestamp")]
		public string Timestamp { get; set; }
	}
}
