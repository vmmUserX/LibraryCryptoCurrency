using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Hitbtc
{
	[Route("/api/2/order", "DELETE")]
	public class CancelOrders : IReturn<CancelOrdersResponse>
	{
		/// <summary>
		/// Optional parameter to filter active orders by symbol
		/// </summary>
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
	}
	[Route("/api/2/order/{ClientOrderId}", "DELETE")]
	public class CancelOrder : IReturn<CancelOrderResponse>
	{
		/// <summary>
		/// Unique identifier for Order as assigned by trader. Uniqueness must be guaranteed within a single trading day, including all active orders
		/// </summary>
		public string ClientOrderId { get; set; }
		/// <summary>
		/// Optional parameter to filter active orders by symbol
		/// </summary>
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
	}
	[DataContract]
	public class CancelOrdersResponse : List<CancelOrderDetail>
	{
	}
	[DataContract]
	public class CancelOrderResponse : CancelOrderDetail
	{
	}
	[DataContract]
	public class CancelOrderDetail
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }
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
