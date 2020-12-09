using System;
using System.Collections.Generic;
using System.Linq;

namespace VendorMachineSample
{
    public class UnavailableCoinTypeException : Exception { }
    public class LackOfValueException : Exception { }

    public class VendorMachine
    {
        private IVendorMachineDatabase Db;
        private CoinSelector CoinSelector = new CoinSelector();
        public List<CoinType> AvailableCoinTypes { get; } = new()
        {
            CoinType.coin10,
            CoinType.coin50,
            CoinType.coin100,
            CoinType.coin500,
            CoinType.bill1000,
        };

        public VendorMachine(IVendorMachineDatabase db)
        {
            Db = db;
        }

        public IEnumerable<Item> GetItems()
        {
            var allItems = Db.GetItemsWithStock();
            return allItems
                    .Where(itemStockPair => itemStockPair.Item2 >= 1)
                    .Select(itemStockPair => itemStockPair.Item1);
        }

        public void InsertCoin(CoinType coinType)
        {
            if (!AvailableCoinTypes.Contains(coinType))
            {
                throw new UnavailableCoinTypeException();
            }
            CoinSelector.AddCoin(coinType);
        }

        public bool IsBuyable(Item item) => item.Price <= CoinSelector.Value;

        public void Buy(Item item)
        {
            if (!IsBuyable(item))
            {
                throw new LackOfValueException();
            }
            Db.EjectItem(item);
        }
    }
}
