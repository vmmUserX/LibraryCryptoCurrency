using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	[Route("/payment/history/size")]
	public class HistorySize : IReturn<HistorySizeResponse>
	{
	}
	[DataContract]
	public class HistorySizeResponse
	{

	}
}