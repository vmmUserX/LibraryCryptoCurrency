using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Hitbtc
{
	[Route("/api/2/public/trades/{Symbol}", "GET")]
	public class TradesPublic : IReturn<TradesPublicResponse>
	{
		public string Symbol { get; set; }
		/// <summary>
		/// Default DESC
		/// </summary>
		[DataMember(Name = "sort")]
		public string Sort { get; set; }
		/// <summary>
		/// Filtration definition.Accepted values: id, timestamp.Default timestamp
		/// </summary>
		[DataMember(Name = "by")]
		public string By { get; set; }
		/// <summary>
		/// Number or Datetime
		/// </summary>
		[DataMember(Name = "from")]
		public string From { get; set; }
		/// <summary>
		/// Number or Datetime
		/// </summary>
		[DataMember(Name = "till")]
		public string Till { get; set; }
		[DataMember(Name = "limit")]
		public int Limit { get; set; }
		[DataMember(Name = "offset")]
		public int Offset { get; set; }
	}
	[DataContract]
	public class TradesPublicResponse : List<TradesPublicDetail>
	{
	}
	[DataContract]
	public class TradesPublicDetail
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