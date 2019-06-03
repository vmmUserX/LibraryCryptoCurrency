using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	[Route("/exchange/commissionCommonInfo")]
	public class CommisionCommonInfo : IReturn<CommisionCommonInfoResponse>
	{
	}
	[DataContract]
	public class CommisionCommonInfoResponse
	{
		[DataMember(Name = "success")]
		public bool Success { get; set; }
		[DataMember(Name = "commission")]
		public decimal Fee { get; set; }
		[DataMember(Name = "last30DaysAmountAsUSD")]
		public decimal AmountUSDFor30Days { get; set; }
	}
}