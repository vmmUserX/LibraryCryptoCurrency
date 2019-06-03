using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Yobit
{
	/**
	 * Класс запроса
	 */
	[Route("/depth")]
	public class GetPairsDepth : IReturn<GetPairsDepthResponse>
	{
	}
	/**
	 * Класс ответа
	 */
	[DataContract]
	public class GetPairsDepthResponse
	{	
	}
}
