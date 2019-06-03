using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Exmo
{
	[Route("/ticker/")]
	public class GetTickers : IReturn<GetTickersResponse>
	{
	}
	[DataContract]
	public class GetTickersResponse : Dictionary<string, GetTickersDetail>
	{
	}
	[DataContract]
	public class GetTickersDetail
	{
		[DataMember(Name = "buy_price")]
		public double AskPrice { get; set; }
		[DataMember(Name = "sell_price")]
		public double BidPrice { get; set; }
		[DataMember(Name = "last_trade")]
		public double Last { get; set; }
		[DataMember(Name = "high")]
		public double High { get; set; }
		[DataMember(Name = "low")]
		public double Low { get; set; }
		[DataMember(Name = "avg")]
		public double Average { get; set; }
		[DataMember(Name = "vol")]
		public double Volume { get; set; }
		[DataMember(Name = "vol_curr")]
		public double VolumeCumm { get; set; }
		[DataMember(Name = "updated")]
		public Int64 Timestamp { get; set; }
	}
}
