using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Hitbtc
{
	[Route("/api/2/order")]
	public class ActiveOrders : IReturn<ActiveOrdersResponse>
	{
		/// <summary>
		/// Optional parameter to filter active orders by symbol
		/// </summary>
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
	}
	[DataContract]
	public class ActiveOrdersResponse : List<ActiveOrdersDetail>
	{
	}
	[DataContract]
	public class ActiveOrdersDetail
	{
		[DataMember(Name = "id")]
		public Int64 Id { get; set; }
		[DataMember(Name = "clientOrderId")]
		public string ClientOrderId { get; set; }
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
		[DataMember(Name = "side")]
		public string Side { get; set; }
		[DataMember(Name = "status")]
		public string Status { get; set; }
		[DataMember(Name = "type")]
		public string TypeOrder { get; set; }
		[DataMember(Name = "timeInForce")]
		public string TimeInForce { get; set; }
		[DataMember(Name = "quantity")]
		public double Quantity { get; set; }
		[DataMember(Name = "price")]
		public double Price { get; set; }
		[DataMember(Name = "cumQuantity")]
		public double CumQuantity { get; set; }
		[DataMember(Name = "createdAt")]
		public string CreatedAt { get; set; }
		[DataMember(Name = "updatedAt")]
		public string UpdatedAt { get; set; }
	}
}