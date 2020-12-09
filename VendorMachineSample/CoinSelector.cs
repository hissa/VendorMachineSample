using System;
using System.Collections.Generic;
using System.Linq;

namespace VendorMachineSample
{
    public enum CoinType { coin1, coin10, coin50, coin100, coin500, bill1000, bill5000, bill10000 };

    public class CoinSelector
    {
        private Dictionary<CoinType, int> CoinsCount = new()
        {
            { CoinType.coin1, 0 },
            { CoinType.coin10, 0 },
            { CoinType.coin50, 0 },
            { CoinType.coin100, 0 },
            { CoinType.coin500, 0 },
            { CoinType.bill1000, 0 },
            { CoinType.bill5000, 0 },
            { CoinType.bill10000, 0 },
        };

        private static Dictionary<CoinType, int> CoinValues = new()
        {
            { CoinType.coin1, 1 },
            { CoinType.coin10, 10 },
            { CoinType.coin50, 50 },
            { CoinType.coin100, 100 },
            { CoinType.coin500, 500 },
            { CoinType.bill1000, 1000 },
            { CoinType.bill5000, 5000 },
            { CoinType.bill10000, 10000 },
        };

        public int Value => CoinsCount
                        .Select(kvp => CoinValues[kvp.Key] * kvp.Value)
                        .Sum();

        public void AddCoin(CoinType coinType) => CoinsCount[coinType]++;
    }
}
