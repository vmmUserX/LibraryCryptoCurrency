using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	[Route("/exchange/maxbid_minask")]
	public class MaxBidMinAsk : IReturn<MaxBidMinAskResponse>
	{
		public string currencyPair { get; set; }
	}
	[DataContract]
	public class MaxBidMinAskResponse
	{
		[DataMember(Name = "currencyPairs")]
		public List<Pair> CurrencyPairs { get; set; }
	}
	[DataContract]
	public class Pair
	{
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
		[DataMember(Name = "maxBid")]
		public string MaxBid { get; set; }
		[DataMember(Name = "minAsk")]
		public string MinAsk { get; set; }
	}
}