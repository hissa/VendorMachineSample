using System;
using System.Collections.Generic;

namespace VendorMachineSample
{
    // 偽物（モック）
    public class MockVendorMachineDatabase : IVendorMachineDatabase
    {
        public void EjectItem(Item item)
        {
            Console.WriteLine($"{item.Name}が排出されました。");
        }

        public IEnumerable<(Item, int)> GetItemsWithStock()
        {
            return new (Item, int)[]
            {
                (new Item(1, "飲料A", 100), 5),
                (new Item(2, "飲料B", 120), 1),
                (new Item(3, "飲料C", 110), 0),
            };
        }
    }
}
