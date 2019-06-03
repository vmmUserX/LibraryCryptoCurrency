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
	/// Return the actual list of available currencies, tokens, ICO etc.
	/// </summary>
	[Route("/api/2/public/currency/{Currency}")]
	public class Currencies : IReturn<CurrenciesResponse>
	{
		public string Currency { get; set; }
	}
	[Route("/api/2/public/currency")]
	public class CurrenciesList : IReturn<List<CurrenciesResponse>>
	{
	}
	/// <summary>
	/// Return the actual list of available currencies, tokens, ICO etc.
	/// </summary>
	[DataContract]
	public class CurrenciesResponse
	{
		/// <summary>
		/// Currency identifier. In the future, the description will simply use the currency
		/// </summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }
		/// <summary>
		/// Currency full name
		/// </summary>
		[DataMember(Name = "fullName")]
		public string FullName { get; set; }
		/// <summary>
		/// Is currency belongs to blockchain (false for ICO and fiat, like EUR)
		/// </summary>
		[DataMember(Name = "crypto")]
		public bool Crypto { get; set; }
		/// <summary>
		/// Is allowed for deposit (false for ICO)
		/// </summary>
		[DataMember(Name = "payinEnabled")]
		public bool PayinEnabled { get; set; }
		/// <summary>
		/// Is required to provide additional information other than the address for deposit
		/// </summary>
		[DataMember(Name = "payinPaymentId")]
		public bool PayinPaymentId { get; set; }
		/// <summary>
		/// Blocks confirmations count for deposit
		/// </summary>
		[DataMember(Name = "payinConfirmations")]
		public int PayinConfirmations { get; set; }
		/// <summary>
		/// Is allowed for withdraw (false for ICO)
		/// </summary>
		[DataMember(Name = "payoutEnabled")]
		public bool PayoutEnabled { get; set; }
		/// <summary>
		/// Is allowed to provide additional information for withdraw
		/// </summary>
		[DataMember(Name = "payoutIsPaymentId")]
		public bool PayoutIsPaymentId { get; set; }
		/// <summary>
		/// Is allowed to transfer between trading and account (may be disabled on maintain)
		/// </summary>
		[DataMember(Name = "transferEnabled")]
		public bool TransferEnabled { get; set; }
		/// <summary>
		/// True if currency delisted (stopped deposit and trading)
		/// </summary>
		[DataMember(Name = "delisted")]
		public bool Delisted { get; set; }
		/// <summary>
		/// Default withdraw fee
		/// </summary>
		[DataMember(Name = "payoutFee")]
		public double PayoutFee { get; set; }
	}
}
 