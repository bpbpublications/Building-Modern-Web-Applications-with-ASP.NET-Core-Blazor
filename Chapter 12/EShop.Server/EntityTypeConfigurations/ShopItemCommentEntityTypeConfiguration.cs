using EShop.Server.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Server.EntityTypeConfigurations;

public class ShopItemCommentEntityTypeConfiguration : BaseEntityTypeConfiguration<ShopItemComment>
{
    protected override string TableName => "ShopItemComment";

    protected override void ConfigureInternal(EntityTypeBuilder<ShopItemComment> builder)
    {
        builder.Property(e => e.Content).IsRequired();
        builder.HasOne(e => e.ShopItem)
            .WithMany(d => d.ShopItemComments)
            .HasForeignKey(e => e.ShopItemId);
    }
}