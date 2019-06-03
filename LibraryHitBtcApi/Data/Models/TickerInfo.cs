using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Hitbtc
{
	[Route("/api/2/public/ticker")]
	public class TickerInfo : IReturn<TickerInfoResponse>
	{
		/// <summary>
		/// Optional parameter to filter active orders by symbol
		/// </summary>
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
	}
	[DataContract]
	public class TickerInfoResponse : List<TickerInfoDetail>
	{
	}
	[DataContract]
	public class TickerInfoDetail
	{
		/// <summary>
		/// Best ask price
		/// </summary>
		[DataMember(Name = "ask")]
		public double Ask { get; set; }
		/// <summary>
		/// Best bid price
		/// </summary>
		[DataMember(Name = "bid")]
		public double Bid { get; set; }
		/// <summary>
		/// Last trade price
		/// </summary>
		[DataMember(Name = "last")]
		public double Last { get; set; }
		/// <summary>
		/// Last trade price 24 hours ago
		/// </summary>
		[DataMember(Name = "open")]
		public double Open { get; set; }
		/// <summary>
		/// Lowest trade price within 24 hours
		/// </summary>
		[DataMember(Name = "low")]
		public double Low { get; set; }
		/// <summary>
		/// Highest trade price within 24 hours
		/// </summary>
		[DataMember(Name = "high")]
		public double High { get; set; }
		/// <summary>
		/// Total trading amount within 24 hours in base currency
		/// </summary>
		[DataMember(Name = "volume")]
		public double Volume { get; set; }
		/// <summary>
		/// Total trading amount within 24 hours in quote currency
		/// </summary>
		[DataMember(Name = "volumeQuote")]
		public double VolumeQuote { get; set; }
		/// <summary>
		/// Last update or refresh ticker timestamp
		/// </summary>
		[DataMember(Name = "timestamp")]
		public string Timestamp { get; set; }
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
	}
}