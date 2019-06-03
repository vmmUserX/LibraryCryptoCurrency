using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	[Route("/exchange/ticker")]
	public class Ticker : IReturn<TickerResponse>
	{
	}
	[Route("/exchange/ticker", "GET")]
	public class TickerPair : IReturn<TickerPairResponse>
	{
		[DataMember(Name = "currencyPair")]
		public string CurrencyPair { get; set; }
	}
	[DataContract]
	public class TickerResponse : List<TickerPairResponse>
	{
	}
	[DataContract]
	public class TickerPairResponse
	{
		[DataMember(Name = "cur")]
		public string Cur { get; set; }
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
		[DataMember(Name = "last")]
		public double Last { get; set; }
		[DataMember(Name = "hight")]
		public double High { get; set; }
		[DataMember(Name = "low")]
		public double Low { get; set; }
		[DataMember(Name = "volume")]
		public double Volume { get; set; }
		[DataMember(Name = "vwap")]
		public double Vwap { get; set; }
		[DataMember(Name = "max_bid")]
		public double MaxBid { get; set; }
		[DataMember(Name = "min_ask")]
		public double MinAsk { get; set; }
		[DataMember(Name = "best_bid")]
		public double BestBid { get; set; }
		[DataMember(Name = "best_ask")]
		public double BestAsk { get; set; }
	}
}