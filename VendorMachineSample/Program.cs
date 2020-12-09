using System;
using System.Collections.Generic;
using System.Linq;

namespace VendorMachineSample
{
    class Program
    {
        private static VendorMachine VendorMachine = new(new MockVendorMachineDatabase());

        private static Dictionary<CoinType, string> CoinTexts = new()
        {
            { CoinType.coin1, "1" },
            { CoinType.coin10, "10" },
            { CoinType.coin50, "50" },
            { CoinType.coin100, "100" },
            { CoinType.coin500, "500" },
            { CoinType.bill1000, "1000" },
            { CoinType.bill5000, "5000" },
            { CoinType.bill10000, "10000" },
        };
        static void Main(string[] args)
        {
            static string ItemToText(Item item) => $"{item.Id}: {item.Name} ({item.Price}円)";
            var itemsText = string.Join(Environment.NewLine, VendorMachine.GetItems().Select(ItemToText));
            var coinTypesText = $"({string.Join(", ", VendorMachine.AvailableCoinTypes.Select(t => CoinTexts[t]))})";

            Console.WriteLine(itemsText);
            Console.WriteLine("Insert coins.(Type `end` to end coin insertion.)");
            Console.WriteLine(coinTypesText);

            while(true)
            {
                var input = Console.ReadLine();
                if (input == "end") break;
                if (!CoinTexts.Values.Contains(input))
                {
                    Console.WriteLine("Error");
                    continue;
                }
                var type = CoinTexts.First(kvp => kvp.Value == input).Key;
                if (!VendorMachine.AvailableCoinTypes.Contains(type))
                {
                    Console.WriteLine("Unavailable");
                    continue;
                }
                VendorMachine.InsertCoin(type);
            }

            Console.WriteLine(itemsText);
            var inputItemId = Console.ReadLine();
            if (!int.TryParse(inputItemId, out var itemId))
            {
                Console.WriteLine("Error");
            }
            if(!VendorMachine.GetItems().Select(i => i.Id).Contains(itemId))
            {
                Console.WriteLine("Item id is not found.");
            }
            var item = VendorMachine.GetItems().FirstOrDefault(item => item.Id == itemId);
            VendorMachine.Buy(item);
            Console.WriteLine("Thank you!");
        }
    }
}
