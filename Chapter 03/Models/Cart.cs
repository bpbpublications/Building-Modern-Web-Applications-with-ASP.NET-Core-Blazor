namespace EShop.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }

        public string User { get; set; }

        public Cart(string user)
        {
            Items = new List<CartItem>();
            User = user;
        }

        public void Add(CartItem item)
        {
            Items.Add(item);
        }

        public void Remove(CartItem item)
        {
            Items.Remove(item);
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}