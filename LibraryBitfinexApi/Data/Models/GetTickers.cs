using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Bitfinex
{
	[Route("/tickers")]
	public class GetTickers : IReturn<GetTickerResponse>
	{
		[DataMember(Name = "symbols")]
		public string Symbols { get; set; }
	}
	[DataContract]
	public class GetTickerResponse : List<GetTickersDetail>
	{
	}
	public class GetTickersDetail /*: List<string>*/
	{
		[DataMember(Name = "mid")]
		public double Mid { get; set; }
		[DataMember(Name = "bid")]
		public double Bid { get; set; }
		[DataMember(Name = "ask")]
		public double Ask { get; set; }
		[DataMember(Name = "last_price")]
		public double LastPrice { get; set; }
		[DataMember(Name = "low")]
		public double Low { get; set; }
		[DataMember(Name = "high")]
		public double High { get; set; }
		[DataMember(Name = "volume")]
		public double Volume { get; set; }
		[DataMember(Name = "timestamp")]
		public double Timestamp { get; set; }
		[DataMember(Name = "pair")]
		public string Symbol { get; set; }
	}
}
