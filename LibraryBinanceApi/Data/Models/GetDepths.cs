using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Binance
{
	[Route("/api/v1/depth", "GET")]
	public class GetDepths : IReturn<GetDepthsResponse>
	{
		public string symbol { get; set; }
		public int limit { get; set; }
	}
	[DataContract]
	public class GetDepthsResponse
	{
		[DataMember(Name = "lastUpdateId")]
		public Int64 LastUpdateId { get; set; }
		[DataMember(Name = "bids")]
		public List<BidAskDepthDetail> Bids { get; set; }
		[DataMember(Name = "asks")]
		public List<BidAskDepthDetail> Asks { get; set; }
	}
	[DataContract]
	public class BidAskDepthDetail : List<object>
	{
	}
}
