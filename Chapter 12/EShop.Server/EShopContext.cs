using EShop.Server.Data;
using EShop.Server.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EShop.Server;

public partial class EShopContext : DbContext
{
    public EShopContext(DbContextOptions<EShopContext> options) : base(options) { }

    public DbSet<ShopItem> ShopItems { get; set; }
    public DbSet<ShopItemComment> ShopItemComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ShopItemEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ShopItemCommentEntityTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}