using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	/// <summary>
	/// Возвращает общую информацию по критовалютам
	/// </summary>
	[Route("/info/coinInfo")]
	public class CoinInfo : IReturn<CoinInfoResponse>
	{
	}
	[DataContract]
	public class CoinInfoResponse
	{
		[DataMember(Name = "success")]
		public bool Success { get; set; }
		[DataMember(Name = "minimalOrderBTC")]
		public string MinimalOrderBtc { get; set; }
		[DataMember(Name = "info")]
		public CoinPairInfo[] PairInfo { get; set; }
	}
	[DataContract]
	public class CoinPairInfo
	{
		/// <summary>
		/// Название
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }
		/// <summary>
		/// Символ
		/// </summary>
		[DataMember(Name = "symbol")]
		public string Symbol { get; set; }
		/// <summary>
		/// Статус кошелька:
		/// normal - Кошелек работает нормально
		/// delayed - Кошелек задерживается(нет нового блока 1-2 часа)
		/// blocked - Кошелек не синхронизирован(нет нового блока минимум 2 часа)
		/// blocked_long - Последний блок получен более 24 ч.назад
		/// down - Кошелек временно выключен
		/// delisted - Монета будет удалена с биржи, заберите свои средства
		/// closed_cashin - Разрешен только вывод
		/// closed_cashout - Разрешен только ввод
		/// </summary>
		[DataMember(Name = "walletStatus")]
		public string WalletStatus { get; set; }
		/// <summary>
		/// Комиссия за вывод
		/// </summary>
		[DataMember(Name = "withdrawFee")]
		public double WithdrawFee { get; set; }
		/// <summary>
		/// Минимальная сумма пополнения
		/// </summary>
		[DataMember(Name = "minDepositAmount")]
		public long MinDepositAmount { get; set; }
		/// <summary>
		/// Минимальная сумма вывода
		/// </summary>
		[DataMember(Name = "minWithdrawAmount")]
		public double MinWithdrawAmount { get; set; }
	}
}