using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace EShop.Server.Pages;

public partial class ShopItem : ComponentBase
{
    [Parameter]
    public int Id { get; set; }

    private EShop.Server.Data.ShopItem _model;

    [Inject]
    public IDbContextFactory<EShopContext> DbFactory { get; set; }

    protected override Task OnInitializedAsync()
    {
        try
        {
            using var context = DbFactory.CreateDbContext();
            _model = context.ShopItems.Where(m => m.Id == Id).Include(s => s.ShopItemComments).First();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return base.OnInitializedAsync();
    }
}