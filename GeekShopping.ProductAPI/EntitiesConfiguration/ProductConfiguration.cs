using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShopping.ProductAPI.Entities;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql( "gen_random_uuid()" ).ValueGeneratedOnAdd();
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("now()").ValueGeneratedOnAdd();
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("now()").ValueGeneratedOnUpdate();
        
        builder.HasData(new Product
        {
            Id = Guid.NewGuid(),
            Name = "Product 1",
            Description = "Description of Product 1",
            Price = 100
        });
        
        builder.HasData(new Product
        {
            Id = Guid.NewGuid(),
            Name = "Product 2",
            Description = "Description of Product 2",
            Price = 150
        });
        
        builder.HasData(new Product
        {
            Id = Guid.NewGuid(),
            Name = "Product 3",
            Description = "Description of Product 3",
            Price = 180
        });
    }
}