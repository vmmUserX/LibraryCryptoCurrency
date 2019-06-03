using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	[Route("/exchange/client_orders")]
	public class ClientOrders : IReturn<ClientOrdersResponse>
	{
		public string currencyPair { get; set; }
		public string openClosed { get; set; }
		public Int64 issuedFrom { get; set; }
		public Int64 issuedTo { get; set; }
		public int startRow { get; set; }
		public int endRow { get; set; }
	}
	[DataContract]
	public class ClientOrdersResponse
	{
		[DataMember(Name = "totalRows")]
		public Int64 TotalRows { get; set; }
		[DataMember(Name = "startRow")]
		public Int64 StartRow { get; set; }
		[DataMember(Name = "endRow")]
		public Int64 EndRow { get; set; }
		[DataMember(Name = "data")]
		public List<PlacedOrders> Data { get; set; }
	}
	[DataContract]
	public class PlacedOrders
	{
		[DataMember(Name = "id")]
		public long Id { get; set; }
		[DataMember(Name = "currencyPair")]
		public string CurrencyPair { get; set; }
		[DataMember(Name = "goodUntilTime")]
		public long GoodUntilTime { get; set; }
		[DataMember(Name = "type")]
		public OrderType Type { get; set; }
		[DataMember(Name = "orderStatus")]
		public OrderStatus OrderStatus { get; set; }
		[DataMember(Name = "issueTime")]
		public long IssueTime { get; set; }
		[DataMember(Name = "price")]
		public object Price { get; set; }
		[DataMember(Name = "quantity")]
		public double Quantity { get; set; }
		[DataMember(Name = "remainingQuantity")]
		public long RemainingQuantity { get; set; }
		[DataMember(Name = "commission")]
		public object Commission { get; set; }
		[DataMember(Name = "commissionRate")]
		public double CommissionRate { get; set; }
		[DataMember(Name = "lastModificationTime")]
		public long LastModificationTime { get; set; }
	}
	public enum OrderType
	{
		Market_Sell,
		Limit_Sell
	}
	public enum OrderStatus
	{
		All,
		Open,
		Closed,
		Not_Cancelled,
		Executed,
		Partially
	}
}