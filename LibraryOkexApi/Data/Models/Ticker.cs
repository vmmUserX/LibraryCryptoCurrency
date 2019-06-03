using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Okex
{
	[Route("/api/futures/v3/instruments/ticker")]
	public class Ticker : IReturn<TickerResponse>
	{
	}
	[DataContract]
	public class TickerResponse : List<TickerDetail>
	{
	}
	[DataContract]
	public class TickerDetail
	{
		[DataMember(Name = "instrument_id")]
		public string InstrumentId { get; set; }
		[DataMember(Name = "last")]
		public double Last { get; set; }
		[DataMember(Name = "best_bid")]
		public double BestBid { get; set; }
		[DataMember(Name = "best_ask")]
		public double BestAsk { get; set; }
		[DataMember(Name = "high_24h")]
		public double High24h { get; set; }
		[DataMember(Name = "low_24h")]
		public double Low24h { get; set; }
		[DataMember(Name = "volume_24h")]
		public double Volume24h { get; set; }
		[DataMember(Name = "timestamp")]
		public string Timestamp { get; set; }
	}
}