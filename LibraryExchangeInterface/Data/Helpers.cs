using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface
{
	public enum DateTicksType
	{
		Epoch = 1,
		EpochTicks,
		Date
	}

	public class Helpers
	{
		public static string GetServerTimeTicks(int type)
		{
			string ret = GetServerTimeTicks(type, -1, default);

			return ret;
		}
		// Перегрузка функции без указания таймштампа
		public static string GetServerTimeTicks(int type, DateTime dt)
		{
			string ret = GetServerTimeTicks(type, -1, dt);

			return ret;
		}
		// Перегрузка функции без указания даты и времени
		public static string GetServerTimeTicks(int type, Int64 timeToConvertion)
		{
			string ret = GetServerTimeTicks(type, timeToConvertion, default);

			return ret;
		}
		public static string GetServerTimeTicks(int type, Int64 timeToConvertion, DateTime dt = default, bool useMilliseconds = true)
		{
			string serverTime = "";
			var utcDate = DateTime.Now.ToUniversalTime();
			long baseTicks = 621355968000000000;
			long tickResolution = useMilliseconds == false ? 10000000 : 10000;
			long epoch = timeToConvertion == -1 ? (utcDate.Ticks - baseTicks) / tickResolution : timeToConvertion;
			long epochTicks = (epoch * tickResolution) + baseTicks;
			//Debug.WriteLine(String.Format("epochTicks = {0}", epochTicks));
			DateTime date = dt == default ? new DateTime(epochTicks, DateTimeKind.Utc).AddHours(3) : dt;

			if (type == (int)DateTicksType.Epoch) serverTime = epoch.ToString();
			else if (type == (int)DateTicksType.EpochTicks) serverTime = epochTicks.ToString();
			// 2017-05-12T14:57:19.999Z
			else if (type == (int)DateTicksType.Date) serverTime = useMilliseconds == false ? date.ToString() : date.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff'Z'");

			return serverTime;
		}
		/// <summary>
		/// Преобразование числа с плавающей запятой типа Double в стринг. Шаблон для преобразования - 0.############
		/// </summary>
		/// <param name="value">Число</param>
		/// <param name="culture">Культура и региональная информация, по умолчанию используется как InvariantCulture. При необходимости можно использовать свой тип культуры</param>
		/// <returns>Возвращает строку</returns>
		public static string ConvertDoubleToString(double value, CultureInfo culture = default)
		{
			CultureInfo cultureInfo = culture == default ? CultureInfo.InvariantCulture : culture;
			string str = value.ToString("0.############", cultureInfo);

			return "";
		}
	}
}