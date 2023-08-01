namespace EShop.WebAssembly.Models
{
    public class WishList
    {
        public List<WishListItem> Items { get; set; }

        public string User { get; set; }

        public WishList(string user)
        {
            Items = new List<WishListItem>();
            User = user;
        }

        public void Add(WishListItem item)
        {
            Items.Add(item);
        }

        public void Remove(WishListItem item)
        {
            Items.Remove(item);
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}