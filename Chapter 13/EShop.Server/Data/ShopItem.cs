namespace EShop.Server.Data;

public partial class ShopItem : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public double Price { get; set; }

    public List<ShopItemComment> ShopItemComments { get; }
}