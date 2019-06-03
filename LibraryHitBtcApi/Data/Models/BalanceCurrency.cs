using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Hitbtc
{
	[Route("/api/2/trading/balance")]
	public class BalanceCurrency : IReturn<BalanceCurrencyResponse>
	{
	}
	[DataContract]
	public class BalanceCurrencyResponse : List<BalanceCurrencyDetail>
	{
	}
	[DataContract]
	public class BalanceCurrencyDetail
	{
		[DataMember(Name = "currency")]
		public string Currency { get; set; }
		/// <summary>
		/// Amount available for trading or transfer to main account
		/// </summary>
		[DataMember(Name = "available")]
		public double Available { get; set; }
		/// <summary>
		/// Amount reserved for active orders or incomplete transfers to main account
		/// </summary>
		[DataMember(Name = "reserved")]
		public double Reserved { get; set; }
	}
}
