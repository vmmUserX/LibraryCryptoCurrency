using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	[Route("/payment/history/transactions")]
	public class Transactions : IReturn<TransactionsResponse>
	{
	}
	[DataContract]
	public class TransactionsResponse : List<Transaction>
	{
	}
	[DataContract]
	public class Transaction
	{
		[DataMember(Name = "id")]
		public string Id { get; set; }
		[DataMember(Name = "type")]
		public TransactionType TransactionType { get; set; }
		[DataMember(Name = "date")]
		public Int64 Date { get; set; }
		[DataMember(Name = "amount")]
		public double Amount { get; set; }
		[DataMember(Name = "fee")]
		public double Fee { get; set; }
		[DataMember(Name = "fixedCurrency")]
		public string FixedCurrency { get; set; }
		[DataMember(Name = "taxCurrency")]
		public string TaxCurrency { get; set; }
		[DataMember(Name = "variableAmount")]
		public double? VariableAmount { get; set; }
		[DataMember(Name = "variableCurrency")]
		public string VariableCurrency { get; set; }
		[DataMember(Name = "external")]
		public string External { get; set; }
		[DataMember(Name = "login")]
		public string Login { get; set; }
	}
	public enum TransactionType
	{
		Buy,
		Sell,
		Deposit,
		Witdrawal
	}
}