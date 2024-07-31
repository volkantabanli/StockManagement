using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("Stocks").HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.StokMRK).HasColumnName("StokMRK");
        builder.Property(s => s.StokIZM).HasColumnName("StokIZM");
        builder.Property(s => s.StokANK).HasColumnName("StokANK");
        builder.Property(s => s.StokADN).HasColumnName("StokADN");
        builder.Property(s => s.StokERZ).HasColumnName("StokERZ");
        builder.Property(s => s.MaterialId).HasColumnName("MaterialId");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");
        builder.HasOne(b => b.Material);
        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}