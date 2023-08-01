namespace EShop.Models
{
    public class Comment
    {
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedTime { get; set; }

        public Comment(string content, string imageUrl)
        {
            Content = content;
            ImageUrl = imageUrl;
            CreatedTime = DateTime.Now;
        }
    }
}