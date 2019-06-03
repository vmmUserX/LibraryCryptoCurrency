using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	[Route("/payment/balances")]
	public class Balances : IReturn<BalancesResponse>
	{
		public string currencyPair { get; set; }
	}
	[Route("/payment/balance")]
	public class Balance : IReturn<BalanceResponse>
	{
		public string currencyPair { get; set; }
	}
	[DataContract]
	public class BalancesResponse : List<BalancesInfo>
	{

	}
	[DataContract]
	public class BalanceResponse : BalancesInfo
	{

	}
	[DataContract]
	public class BalancesInfo
	{
		[DataMember(Name = "type")]
		public string Type { get; set; }
		[DataMember(Name = "currency")]
		public string Currency { get; set; }
		[DataMember(Name = "value")]
		public int Value { get; set; }
	}
}