using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.KuCoin
{
	[Route("/v1/open/tick")]
	public class Tick : IReturn<TickResponse>
	{
	}
	[DataContract]
	public class TickResponse
	{
		[DataMember(Name = "success")]
		public string Success { get; set; }
		[DataMember(Name = "code")]
		public string Code { get; set; }
		[DataMember(Name = "msg")]
		public string Message { get; set; }
		[DataMember(Name = "timestamp")]
		public Int64 TimestampResponse { get; set; }
		[DataMember(Name = "data")]
		public List<TickDetail> Data { get; set; }
	}
	[DataContract]
	public class TickDetail
	{
		[DataMember(Name = "coinType")]
		public string CoinType { get; set; }
		[DataMember(Name = "trading")]
		public bool Trading { get; set; }
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
		[DataMember(Name = "lastDealPrice")]
		public double LastDealPrice { get; set; }
		[DataMember(Name = "buy")]
		public double Buy { get; set; }
		[DataMember(Name = "sell")]
		public double Sell { get; set; }
		[DataMember(Name = "coinTypePair")]
		public string CoinTypePair { get; set; }
		[DataMember(Name = "sort")]
		public int Sort { get; set; }
		[DataMember(Name = "feeRate")]
		public double FeeRate { get; set; }
		[DataMember(Name = "volValue")]
		public double VolValue { get; set; }
		[DataMember(Name = "high")]
		public double High { get; set; }
		[DataMember(Name = "datetime")]
		public Int64 Datetime { get; set; }
		[DataMember(Name = "vol")]
		public double Volume { get; set; }
		[DataMember(Name = "low")]
		public double Low { get; set; }
	}
}