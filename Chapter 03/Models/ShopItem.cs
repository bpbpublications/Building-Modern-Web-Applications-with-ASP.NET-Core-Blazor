namespace EShop.Models
{
    public class ShopItem
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public ShopItem(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}