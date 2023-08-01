using EShop.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Server.EntityTypeConfigurations;

public class ShopItemEntityTypeConfiguration : BaseEntityTypeConfiguration<ShopItem>
{
    protected override string TableName => "ShopItem";

    protected override void ConfigureInternal(EntityTypeBuilder<ShopItem> builder)
    {
        builder.Property(e => e.Name).IsRequired().HasMaxLength(10);
        builder.Property(e => e.Description);
        builder.Property(e => e.ImageUrl).IsRequired().HasColumnName("Image");
        builder.Property(e => e.Price).HasDefaultValue(9.9);
    }
}