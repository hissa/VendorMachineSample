using System;
using System.Collections.Generic;

namespace VendorMachineSample
{
    public interface IVendorMachineDatabase
    {
        public IEnumerable<(Item, int)> GetItemsWithStock();
        public void EjectItem(Item item);
    }
}
