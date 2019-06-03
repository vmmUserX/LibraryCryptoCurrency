using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

/**
* Получение информации о парах
* https://yobit.net/ru/api/
*/
namespace LibraryExchangeInterface.Data.Yobit
{
	/**
	 * Класс запроса
	 */
	[Route("/info")]
	public class GetInfo : IReturn<GetInfoResponse>
	{
	}
	/**
	 * Класс ответа
	 */
	[DataContract]
	public class GetInfoResponse : YobitTradeApiResponse
	{
		[DataMember]
		public int server_time { get; set; }
		[DataMember]
		public Pairs pairs { get; set; }
	}
	public class Pairs : Dictionary<string, PairInfo>
	{
	}
	public class PairInfo
	{
		/// <summary>
		/// количество разрешенных знаков после запятой
		/// </summary>
		public int decimal_places { get; set; }
		/// <summary>
		/// минимальная разрешенная цена
		/// </summary>
		public float min_price { get; set; }
		/// <summary>
		/// максимальная разрешенная цена
		/// </summary>
		public int max_price { get; set; }
		/// <summary>
		/// минимальное разрешенное количество для покупки или продажи
		/// </summary>
		public float min_amount { get; set; }
		/// <summary>
		/// пара скрыта (0 или 1)
		/// </summary>
		public int hidden { get; set; }
		/// <summary>
		/// комиссия пары
		/// </summary>
		public float fee { get; set; }
	}
}
