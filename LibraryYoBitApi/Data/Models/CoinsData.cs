using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface.Data.Yobit
{
	public class CoinsPairs : List<CoinPair>
	{
		public CoinsPairs()
		{

		}

		public CoinsPairs(IEnumerable<CoinPair> coinPairsList)
		{
			this.AddRange(coinPairsList);
		}

		public string UrlPath
		{
			get
			{
				return string.Join("-", this.Select(cp => cp.ToString()));
			}
		}
	}
	public class CoinPair
	{
		public string Coin1 { get; set; }
		public string Coin2 { get; set; }
		public bool Reverted { get; set; }

		public CoinPair(string coin1, string coin2)
		{
			Coin1 = coin1;
			Coin2 = coin2;

			// для пары из двух фиатных валуют возможна только такая пара
			if (Coin1 == "rur" && Coin2 == "usd")
			{
				Coin1 = "usd";
				Coin2 = "rur";
				Reverted = true;
				return;
			}
			// для пар с одной фиатной валютой сама фиатная валюта должна быть второй
			//if (Coin1 == "usd" && Coin2 != "rur") {
			//    Coin1 = Coin2;
			//    Coin2 = "usd";
			//    return;
			//}
			//if (Coin1 == "rur" && Coin2 != "usd")
			//{
			//    Coin1 = Coin2;
			//    Coin2 = "rur";
			//    return;
			//}
		}

		public override string ToString()
		{
			return Coin1.ToLower() + "_" + Coin2.ToLower();
		}
	}
}
