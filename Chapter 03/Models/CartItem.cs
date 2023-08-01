using System;

namespace EShop.Models
{
    public class CartItem
    {
        public ShopItem Item { get; set; }

        private int _count;
        public int Count
        {
            get
            {
                Console.WriteLine("gggggggggggggggggggggggggggggggggggggggggggget");
                return _count;
            }
            set
            {
                Console.WriteLine("sssssssssssssssssssssssssssssssssssssssssssset");
                _count = value; UpdateTime = DateTime.Now;
            }
        }

        public DateTime UpdateTime { get; set; } = DateTime.Now;

        public CartItem(ShopItem item, int count)
        {
            Item = item;
            Count = count;
        }
    }
}