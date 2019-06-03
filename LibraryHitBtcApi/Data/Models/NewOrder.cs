using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Hitbtc
{
	[Route("/api/2/order/")]
	[Route("/api/2/order/{ClientOrderId}")]
	public class NewOrder : IReturn<NewOrderResponse>
	{
		/// <summary>
		/// Unique identifier for Order as assigned by trader. Uniqueness must be guaranteed within a single trading day, including all active orders
		/// </summary>
		public string ClientOrderId { get; set; }
		/// <summary>
		/// Trading symbol
		/// </summary>
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
		/// <summary>
		/// sell buy
		/// </summary>
		[DataMember(Name = "side")]
		public string Side { get; set; }
		/// <summary>
		/// Optional.Default - limit.One of: limit, market, stopLimit, stopMarket
		/// </summary>
		[DataMember(Name = "type")]
		public string TypeOrder { get; set; }
		/// <summary>
		/// Optional.Default - GDC.One of: GTC, IOC, FOK, Day, GTD
		/// Time in force is a special instruction used when placing a trade to indicate how long an order will remain active before it is executed or expires
		/// GTC - Good till cancel. GTC order won't close until it is filled
		/// IOC - An immediate or cancel order is an order to buy or sell that must be executed immediately, and any portion of the order that cannot be immediately filled is cancelled
		/// FOK - Fill or kill is a type of time-in-force designation used in securities trading that instructs a brokerage to execute a transaction immediately and completely or not at all
		/// Day - keeps the order active until the end of the trading day in UTC
		/// GTD - Good till date specified in expireTime
		/// </summary>
		[DataMember(Name = "timeInForce")]
		public string TimeInForce { get; set; }
		/// <summary>
		/// Order quantity
		/// </summary>
		[DataMember(Name = "quantity")]
		public double Quantity { get; set; }
		/// <summary>
		/// Order price. Required for limit types
		/// </summary>
		[DataMember(Name = "price")]
		public double Price { get; set; }
		/// <summary>
		/// Required for stop types
		/// </summary>
		[DataMember(Name = "stopPrice")]
		public double StopPrice { get; set; }
		/// <summary>
		/// Required for GTD timeInForce
		/// </summary>
		[DataMember(Name = "expireTime")]
		public string ExpireTime { get; set; }
		/// <summary>
		/// Price and quantity will be checked that they increment within tick size and quantity step. See symbol tickSize and quantityIncrement
		/// </summary>
		[DataMember(Name = "strictValidate")]
		public bool StrictValidate { get; set; }
	}
	[DataContract]
	public class NewOrderResponse
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