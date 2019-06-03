using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface
{
	public class TickerInformation
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
		public Int64 TimestampOpen { get; set; }
		[DataMember(Name = "timestamp")]
		public Int64 TimestampClose { get; set; }
		/// <summary>
		/// Last update or refresh ticker timestamp (Original)
		/// </summary>
		[DataMember(Name = "datetimeopenorig")]
		public string DateTimeOpenOrig { get; set; }
		[DataMember(Name = "datetimecloseorig")]
		public string DateTimeCloseOrig { get; set; }
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
	}
}