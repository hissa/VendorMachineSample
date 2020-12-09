using System;
namespace VendorMachineSample
{
    public struct Item
    {
        public int Id { get; }
        public string Name { get; }
        public int Price { get; }

        public Item(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
