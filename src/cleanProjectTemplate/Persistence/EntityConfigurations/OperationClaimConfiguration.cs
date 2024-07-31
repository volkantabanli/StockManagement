using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region Materials
        seeds.Add(new OperationClaim { Id = ++id, Name = "Materials.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Materials.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Materials.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Materials.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Materials.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Materials.Delete" });
        #endregion
        #region Models
        seeds.Add(new OperationClaim { Id = ++id, Name = "Models.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Models.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Models.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Models.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Models.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Models.Delete" });
        #endregion
        #region Stocks
        seeds.Add(new OperationClaim { Id = ++id, Name = "Stocks.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Stocks.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Stocks.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Stocks.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Stocks.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Stocks.Delete" });
        #endregion
        return seeds;
    }
}
