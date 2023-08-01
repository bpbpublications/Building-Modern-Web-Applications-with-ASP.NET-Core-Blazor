using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace EShop.Server.Pages;

public partial class AddShopItem : ComponentBase
{
    private EShop.Server.Data.ShopItem _shopItem = new Data.ShopItem();

    [Inject]
    public IDbContextFactory<EShopContext> DbFactory { get; set; }

    private void HandleValidSubmit()
    {
        try
        {
            using var context = DbFactory.CreateDbContext();
            context.ShopItems.Add(_shopItem);
            context.SaveChanges();
            _shopItem = new Data.ShopItem();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}