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
            builder.Property(ub => ub.Amount).HasColumnName("Amount").HasMaxLength(50);
            builder.Property(ub => ub.BookingDate).HasColumnName("BookingDate").HasMaxLength(50);
            builder.Property(ub => ub.ReturnDate).HasColumnName("ReturnDate").HasMaxLength(50);

            builder.HasOne(ub => ub.User).WithMany(ub => ub.UserBooks).HasForeignKey(u => u.UserId);
        }
    }
}
