using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLibrary.Core.Entities;

namespace OnlineLibrary.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserBookMap : IEntityTypeConfiguration<UserBook>
    {
        public void Configure(EntityTypeBuilder<UserBook> builder)
        {
            builder.ToTable(@"UserBooks", @"dbo");

            builder.HasKey(ub => ub.Id);

            builder.Property(ub => ub.Name).HasColumnName("Name").HasMaxLength(50);
            builder.Property(ub => ub.Amount).HasColumnName("Amount");
            builder.Property(ub => ub.Stock).HasColumnName("Stock");
            builder.Property(ub => ub.ReservedDate).HasColumnName("ReservedDate");
            builder.Property(ub => ub.ReturnedDate).HasColumnName("ReturnedDate");

            builder.HasOne(ub => ub.User).WithMany(ub => ub.UserBooks).HasForeignKey(u => u.UserId);
        }
    }
}
