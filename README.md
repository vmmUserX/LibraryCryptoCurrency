# C#
## Library Exchange for Crypto Currency Market

### Library to connect through the following API Crypto exchanges:

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

      /// <summary>Loading exchanges.</summary>
      
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
             .... TODO
      }
      /// <summary>Loading only one exchange by name.</summary>
      
      private IExchangeInterface GetExchangeByName(string name)
      {
            IExchangeInterface exchange = exchangesList.Where(x => x.LibraryName == name).First();
            return exchange;
      }
}


<p align="center">
  <img src="https://user-images.githubusercontent.com/40513889/59661595-cf9f2e00-91b3-11e9-9b25-7ecd3547e160.jpg" width="480" height="700" hspace="20" />
  <img src="https://user-images.githubusercontent.com/40513889/59661472-9070dd00-91b3-11e9-9b9f-4e05a50373f8.jpg" width="340" height="700" />
</p>
