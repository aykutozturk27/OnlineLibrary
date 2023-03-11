using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLibrary.Core.Entities;

namespace OnlineLibrary.DataAccess.Concrete.EntityFramework.Mappings
{
    public class OperationClaimMap : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable(@"OperationClaims", @"dbo");

            builder.HasKey(u => u.Id);

            builder.Property(a => a.Name).HasColumnName("Name").HasMaxLength(100);
        }
    }
}
