using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Exmo
{
	[Route("/pair_settings")]
	public class PairSettings : IReturn<PairSettingsResponse>
	{
	}
	[DataContract]
	public class PairSettingsResponse : Dictionary<string, object>
	{
	}
	[DataContract]
	public class PairSettingsDetail
	{
		[DataMember(Name = "min_quantity")]
		public double QuantityMin { get; set; }
		[DataMember(Name = "max_quantity")]
		public double QuantityMax { get; set; }
		[DataMember(Name = "min_price")]
		public double PriceMin { get; set; }
		[DataMember(Name = "max_price")]
		public double PriceMax { get; set; }
		[DataMember(Name = "min_amount")]
		public double AmountMin { get; set; }
		[DataMember(Name = "max_amount")]
		public double AmountMax { get; set; }
	}
}