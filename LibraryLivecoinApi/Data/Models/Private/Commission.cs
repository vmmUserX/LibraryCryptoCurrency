using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	[Route("/exchange/commission")]
	public class Commission : IReturn<CommissionResponse>
	{
	}
	[DataContract]
	public class CommissionResponse
	{
		[DataMember(Name = "success")]
		public bool Success { get; set; }
		[DataMember(Name = "fee")]
		public decimal Fee { get; set; }
	}
}