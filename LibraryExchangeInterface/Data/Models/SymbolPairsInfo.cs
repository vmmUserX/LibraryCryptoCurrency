using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface
{
	[DataContract]
	public class SymbolPairsInfo
	{
		/// <summary>
		/// Название валютной пары
		/// </summary>
		[DataMember]
		public string Name { get; set; }
		/// <summary>
		/// Ограничение количества знаков после запятой
		/// </summary>
		[DataMember]
		public int LimitNumberDecimalPlaces { get; set; }
		[DataMember(Name = "tickSize")]
		public double TickSize { get; set; }
	}
}