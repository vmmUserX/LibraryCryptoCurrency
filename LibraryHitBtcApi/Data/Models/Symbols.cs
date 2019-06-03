using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Hitbtc
{
	/// <summary>
	/// Return the actual list of currency symbols (currency pairs) traded on exchange. The first listed currency of a symbol is called the base currency, and the second currency is called the quote currency. The currency pair indicates how much of the quote currency is needed to purchase one unit of the base currency
	/// </summary>
	[Route("/api/2/public/symbol/{Symbol}")]
	public class Symbols : IReturn<SymbolsResponse>
	{
		public string Symbol { get; set; }
	}
	[Route("/api/2/public/symbol")]
	public class SymbolsList : IReturn<List<SymbolsResponse>>
	{
	}
	/// <summary>
	/// Return the actual list of currency symbols (currency pairs) traded on exchange. The first listed currency of a symbol is called the base currency, and the second currency is called the quote currency. The currency pair indicates how much of the quote currency is needed to purchase one unit of the base currency
	/// </summary>
	[DataContract]
	public class SymbolsResponse
	{
		/// <summary>
		/// Symbol identifier. In the future, the description will simply use the symbol
		/// </summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }
		[DataMember(Name = "baseCurrency")]
		public string BaseCurrency { get; set; }
		[DataMember(Name = "quoteCurrency")]
		public string QuoteCurrency { get; set; }
		[DataMember(Name = "quantityIncrement")]
		public double QuantityIncrement { get; set; }
		[DataMember(Name = "tickSize")]
		public double TickSize { get; set; }
		/// <summary>
		/// Default fee rate
		/// </summary>
		[DataMember(Name = "takeLiquidityRate")]
		public double TakeLiquidityRate { get; set; }
		/// <summary>
		/// Default fee rate for market making trades
		/// </summary>
		[DataMember(Name = "provideLiquidityRate")]
		public double ProvideLiquidityRate { get; set; }
		[DataMember(Name = "feeCurrency")]
		public string FeeCurrency { get; set; }
	}
}