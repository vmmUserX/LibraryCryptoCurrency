# LibraryCryptoCurrency
Library Exchange for Crypto Currency Market

Библиотека для подключения через API следующих Крипто бирж:

1 Binance

2 Bitfinex

3 Exmo

4 HitBtc

5 KuCoin

6 Livecoin

7 Okex

8 YoBit

public MainWindow()
{

       InitializeComponent();
       DataContext = this;
       GetExchange();
}

public void GetExchange()
{

      if (exchangesSet == null) exchangesSet = new ExchangesSet("set", "Набор бирж");
      if (exchange == null) exchange = new ExchangeInterface();
      if (exchange.ExchangesCount > 0)
      {
             exchangesList = exchange.GetExchangesList();
             foreach (IExchangeInterface excs in exchangesList)
                    if (excs.LibraryName != "ccxt")
                    {
                        exchangesSet.AddExchangeToSet(excs);
                        if (excs.LibraryEnabled == false) excs.LibraryInit();
                        if (excs.LibraryName == "hitbtc") SelectedExchange = excs;
                    }
             }
             Dictionary<string, List<SymbolPairsInfo>> listCurrencys = exchangesSet.GetListSymbols();
             GetBalanceCurrency = exchangesSet.GetListBalanceCurrency();
             ListActiveOrders = exchangesSet.GetListActiveOrders();
             listTickers = exchangesSet.GetTickers(); 
      }
}

