using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Yobit
{
	public class TradeGetInfo : IReturn<TradeGetInfoResponse>
	{
		
	}
	[DataContract]
	public class TradeGetInfoResponse
	{

	}
}
