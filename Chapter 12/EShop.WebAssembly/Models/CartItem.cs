using System;

namespace EShop.WebAssembly.Models
{
    public class CartItem
    {
        public ShopItem Item { get; set; }

        private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
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