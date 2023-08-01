namespace EShop.Models
{
    public class ShopItem
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public List<Comment> Comments { get; }

        public ShopItem(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }
    }
}