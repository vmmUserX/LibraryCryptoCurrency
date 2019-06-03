using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	[Route("/exchange/restrictions")]
	public class Restrictions : IReturn<RestrictionsResponse>
	{
	}
	[DataContract]
	public class RestrictionsResponse
	{
		[DataMember(Name = "success")]
		public bool Success { get; set; }
		[DataMember(Name = "minBtcVolume")]
		public decimal MinBtcVolume { get; set; }
		[DataMember(Name = "restrictions")]
		public Restriction[] Restrictions { get; set; }
	}
	[DataContract]
	public class Restriction
	{
		[DataMember(Name = "currencyPair")]
		public string CurrencyPair { get; set; }
		[DataMember(Name = "minLimitQuantity")]
		public decimal MinLimitQuantity { get; set; }
		[DataMember(Name = "priceScale")]
		public decimal PriceScale { get; set; }
	}
}
