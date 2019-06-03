// ==<vmm>==
// 
// Files of Library of Crypto Currency Market:
// ExchangeInterface.cs
// Descriptions: Developer for cryptocurrency market on C#
// ==-   -==
// SBT
//
// ======================================================================================
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExchangeInterface
{
	public class ExchangeInterface
	{
		/// <summary>
		/// Словарь для хранения плагинов, где ключ - это название биржи, значение интерфейс реализации
		/// </summary>
		private Dictionary<string, IExchangeInterface> _plugins = new Dictionary<string, IExchangeInterface>();
		/// <summary>
		/// Получаем количество подключенных бирж
		/// </summary>
		public int ExchangesCount { get { return _plugins.Count; } }

		/// <summary>
		/// Конструктор по умолчанию устанавливает папку для плагинов как системную, относительно самой библиотеки LibraryExchangeInterface
		/// </summary>
		public ExchangeInterface()
		{
			// Рабочая версия загрузки LibraryCCXTApi.dll
			/*var dll = Assembly.LoadFrom("LibraryCCXTApi.dll");
			Type[] dllTypes = dll.GetTypes();
			Type type = dllTypes[0];

			IExchangeInterface exchange = (IExchangeInterface)Activator.CreateInstance(type);*/

			Assembly assembly = Assembly.GetExecutingAssembly();

			string folder = String.Format(@"{0}\Plugins", Path.GetDirectoryName(assembly.Location));
			InitLoadPlugins(folder);
		}
		/// <summary>
		/// Конструктор по умолчанию устанавливает папку для плагинов как из вне
		/// </summary>
		/// <param name="folderPlugins">Путь к папке с плагинами</param>
		public ExchangeInterface(string folderPlugins)
		{
			InitLoadPlugins(folderPlugins);
		}

		/// <summary>
		/// Инициализация загрузки плагинов по указанному пути
		/// </summary>
		/// <param name="folder">Путь к папке с плагинами</param>
		private void InitLoadPlugins(string folder)
		{
			LoadPlugins(folder);

			Debug.WriteLine(String.Format("Количество плагинов подключенных к библиотке: {0}", _plugins.Count));
		}
		/// <summary>
		/// Загрузить все Dll с набором API под конкретную биржу и реализующую интерфейс IExchangeInterface
		/// </summary>
		/// <param name="folder">Путь к папке с плагинами</param>
		private void LoadPlugins(string folder)
		{
			foreach (string dll in Directory.GetFiles(folder, "*.dll"))
			{
				Debug.WriteLine(dll);

				try
				{
					Assembly assembly = Assembly.LoadFrom(dll);

					foreach (Type type in assembly.GetTypes())
					{
						if (type.GetInterface("IExchangeInterface") == typeof(IExchangeInterface))
						{
							//Debug.WriteLine(String.Format("DLL: {0} type is founded", dll));

							IExchangeInterface exchange;
							exchange = (IExchangeInterface)Activator.CreateInstance(type);
							string exchangeName = exchange.LibraryName;

							_plugins.Add(exchangeName, exchange);
						}
						//else Debug.WriteLine(String.Format("DLL: {0} type not founded", dll));
					}
				}
				catch (Exception exc)
				{
					Debug.WriteLine(exc.ToString());
				}
			}
		}
		/// <summary>
		/// Получаем конкретную биржу по её имени
		/// </summary>
		/// <param name="name">Название биржи. Будет преобразована в маленькие символы</param>
		/// <returns>Возвращаем конкретную биржу по её имени. Если плагин не был найден, то возвращается null</returns>
		public IExchangeInterface GetExchangeByName(string name)
		{
			name = name.ToLower();

			try
			{
				var exchangeSingle = _plugins.Single(s => s.Key == name);
				IExchangeInterface exchange = exchangeSingle.Value;

				return exchange;
			}
			catch (Exception)
			{
				return null;
			}
		}
		/// <summary>
		/// Получаем список всех бирж в словаре бирж
		/// </summary>
		/// <returns>Возвращаем список всех бирж в словаре бирж</returns>
		public List<IExchangeInterface> GetExchangesList()
		{
			List<IExchangeInterface> listExchanges = new List<IExchangeInterface>();

			foreach (IExchangeInterface exchange in _plugins.Values)
			{
				listExchanges.Add(exchange);
			}

			return listExchanges;
		}
	}
}
