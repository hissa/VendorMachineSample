using System;
using System.Collections.Generic;

namespace VendorMachineSample
{
    // 本当にDBに接続するやつ
    public class VendorMachineDatabase : IVendorMachineDatabase
    {
        public VendorMachineDatabase()
        {
        }

        public void EjectItem(Item item)
        {
            // 商品の在庫を減らす処理
            throw new NotImplementedException();
        }

        public IEnumerable<(Item, int)> GetItemsWithStock()
        {
            // 商品一覧を在庫と一緒に出す処理
            throw new NotImplementedException();
        }
    }
}
