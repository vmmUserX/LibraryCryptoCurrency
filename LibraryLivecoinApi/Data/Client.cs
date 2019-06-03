using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace LibraryExchangeInterface.Data.Livecoin
{
	/// <summary>
	/// Тип торговых операций
	/// </summary>
	public enum TradeType
	{
		/// <summary>
		/// Покупка
		/// </summary>
		Buy,
		/// <summary>
		/// Продажа
		/// </summary>
		Sell,
		/// <summary>
		/// Покупка и продажа
		/// </summary>
		Both
	}

	public class Client
	{
		private string apiKey = "";
		private string apiSecret = "";
		private string apiPath = "https://api.livecoin.net";

		//private IServiceClient CreateClient() => new JsonServiceClient("https://api.livecoin.net");

		public IServiceClient ServiceClient { get; set; }

		public Client(string apikey, string apisecret, string apipath = "")
		{
			apiKey = apikey;
			apiSecret = apisecret;
			if (apipath != "") apiPath = apipath;

			//ServiceClient = CreateClient();
			ServiceClient = new JsonServiceClient(apiPath);
		}
		private string GetTypeNamespace()
		{
			return GetType().Namespace;
		}
		private void WebServiceErrorProcessing(WebServiceException exception, string funcName)
		{
			string exceptionString = String.Format("{0}: {1}():", GetTypeNamespace(), funcName);
			exceptionString += String.Format("\nStatusCode = {0}", exception.StatusCode);
			exceptionString += String.Format("\nStatusDescription = {0}", exception.StatusDescription);
			exceptionString += String.Format("\nErrorCode = {0}", exception.ErrorCode);
			exceptionString += String.Format("\nErrorMessage = {0}", exception.ErrorMessage);
			exceptionString += String.Format("\nStackTrace = {0}", exception.StackTrace);
			exceptionString += String.Format("\nResponseDto = {0}", exception.ResponseDto);
			exceptionString += String.Format("\nResponseStatus = {0}", exception.ResponseStatus);
			exceptionString += String.Format("\nGetFieldErrors() = {0}", exception.GetFieldErrors());

			Debug.WriteLine(exceptionString);
		}

		/// <summary>
		/// Получить ограничения по каждой паре по мин. размеру ордера и максимальному кол-ву знаков после запятой в цене
		/// </summary>
		/// <returns>Возвращает ограничения по каждой паре по мин. размеру ордера и максимальному кол-ву знаков после запятой в цене</returns>
		public RestrictionsResponse GetRestriction()
		{
			try
			{
				var result = ServiceClient.Get(new Restrictions());

				return result;
			}
			catch (WebServiceException exc)
			{
				WebServiceErrorProcessing(exc, "GetRestriction");

				return null;
			}
			catch (WebException exc)
			{
				//WebServiceErrorProcessing(exc, "GetBalances");

				return null;
			}
		}
		public List<BalancesInfo> GetBalances()
		{
			try
			{
				string sign = HashHMAC(apiSecret, "").ToUpper();

				var request = String.Format("{0}{1}", "https://api.livecoin.net", "/payment/balances").GetJsonFromUrl(requestFilter: webReq =>
				{
					webReq.Headers["Api-Key"] = apiKey;
					webReq.Headers["Sign"] = sign;
					webReq.ContentType = "application/x-www-form-urlencoded";
				});

				return new List<BalancesInfo>();
			}
			catch (WebServiceException exc)
			{
				WebServiceErrorProcessing(exc, "GetBalances");

				return new List<BalancesInfo>();
			}
			catch (WebException exc)
			{
				//WebServiceErrorProcessing(exc, "GetBalances");

				return new List<BalancesInfo>();
			}
		}
		public TickerResponse GetTickers()
		{
			var result = ServiceClient.Get(new Ticker());

			return result;
		}
		public TickerPairResponse GetTicker(string symbol = "")
		{
			var result = ServiceClient.Get(new TickerPair());

			return result;
		}
		public OrderBookResponse GetOrderBook(string symbol = "", int limit = default)
		{
			OrderBook ob = new OrderBook();
			if (symbol != "") ob.currencyPair = symbol;
			if (limit != default) ob.depth = limit.ToString();

			var result = ServiceClient.Get(ob);

			return result;
		}

		private string HashHMAC(string key, string message)
		{
			var encoding = new UTF8Encoding();
			var keyByte = encoding.GetBytes(key);

			var hmacsha256 = new HMACSHA256(keyByte);

			var messageBytes = encoding.GetBytes(message);
			var hashmessage = hmacsha256.ComputeHash(messageBytes);

			return ByteArrayToString(hashmessage);
		}
		private string ByteArrayToString(byte[] ba)
		{
			var hex = new StringBuilder(ba.Length * 2);
			foreach (var b in ba)
				hex.AppendFormat("{0:x2}", b);
			return hex.ToString();
		}
	}
}
