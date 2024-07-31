using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaterialConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.ToTable("Materials").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.Name).HasColumnName("Name").IsRequired();
        builder.Property(m => m.Code).HasColumnName("Code").IsRequired();
        builder.Property(m => m.Engine).HasColumnName("Engine");
        builder.Property(m => m.Year).HasColumnName("Year");
        builder.Property(m => m.Price).HasColumnName("Price");
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Materials_Name").IsUnique();
        builder.HasMany(b => b.Models);
        builder.HasMany(b => b.Stocks);
        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}