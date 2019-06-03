using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Binance
{
	[Route("/api/v1/ticker/24hr")]
	public class Statistics24Hour : IReturn<Statistics24HourResponse>
	{
		public string symbol { get; set; }
	}
	[DataContract]
	public class Statistics24HourResponse : List<Statistics24HourDetail>
	{
	}
	[DataContract]
	public class Statistics24HourDetail
	{
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
		[DataMember(Name = "priceChange")]
		public double PriceChange { get; set; }
		[DataMember(Name = "priceChangePercent")]
		public double PriceChangePercent { get; set; }
		[DataMember(Name = "weightedAvgPrice")]
		public double WeightedAvgPrice { get; set; }
		[DataMember(Name = "prevClosePrice")]
		public double PrevClosePrice { get; set; }
		[DataMember(Name = "lastPrice")]
		public double LastPrice { get; set; }
		[DataMember(Name = "lastQty")]
		public double LastQuanity { get; set; }
		[DataMember(Name = "bidPrice")]
		public double BidPrice { get; set; }
		[DataMember(Name = "askPrice")]
		public double AskPrice { get; set; }
		[DataMember(Name = "openPrice")]
		public double OpenPrice { get; set; }
		[DataMember(Name = "highPrice")]
		public double HighPrice { get; set; }
		[DataMember(Name = "LowPrice")]
		public double LowPrice { get; set; }
		[DataMember(Name = "volume")]
		public double Volume { get; set; }
		[DataMember(Name = "quoteVolume")]
		public double QuoteVolume { get; set; }
		[DataMember(Name = "openTime")]
		public Int64 OpenTime { get; set; }
		[DataMember(Name = "closeTime")]
		public Int64 CloseTime { get; set; }
		[DataMember(Name = "firstId")]
		public int FirstId { get; set; }
		[DataMember(Name = "lastId")]
		public int LastId { get; set; }
		[DataMember(Name = "count")]
		public int Count { get; set; }
	}
}
