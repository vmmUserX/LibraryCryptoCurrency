using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface
{
	[DataContract]
	public class BalanceCurrency
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
		[DataMember(Name = "total")]
		public double Total { get; set; }
		[DataMember(Name = "available_withdrawal")]
		public double AvailableWithdrawal { get; set; }
	}
}
