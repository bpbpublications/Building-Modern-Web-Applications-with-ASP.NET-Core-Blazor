namespace EShop.Server.Data;

public partial class ShopItemComment : BaseEntity
{
    public int ShopItemId { get; set; }

    public string Content { get; set; }

    public ShopItem ShopItem { get; set; }
}
