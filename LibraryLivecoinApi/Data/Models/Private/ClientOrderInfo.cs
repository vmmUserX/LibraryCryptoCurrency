using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	[Route("/exchange/order")]
	public class ClientOrderInfo : IReturn<ClientOrderInfoResponse>
	{
		public int orderId { get; set; }
	}
	[DataContract]
	public class ClientOrderInfoResponse
	{
		[DataMember(Name = "id")]
		public long Id { get; set; }
		[DataMember(Name = "client_id")]
		public long ClientId { get; set; }
		[DataMember(Name = "status")]
		public string Status { get; set; }
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
		[DataMember(Name = "price")]
		public double Price { get; set; }
		[DataMember(Name = "quantity")]
		public double Quantity { get; set; }
		[DataMember(Name = "remaining_quantity")]
		public double RemainingQuantity { get; set; }
		[DataMember(Name = "blocked")]
		public double Blocked { get; set; }
		[DataMember(Name = "blocked_remain")]
		public long BlockedRemain { get; set; }
		[DataMember(Name = "commission_rate")]
		public double CommissionRate { get; set; }
		[DataMember(Name = "trades")]
		public object Trades { get; set; }
	}
}