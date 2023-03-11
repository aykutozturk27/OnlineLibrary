using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLibrary.Core.Entities;

namespace OnlineLibrary.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(@"Users", @"dbo");

            builder.HasKey(u => u.Id);

            builder.Property(a => a.FirstName).HasColumnName("FirstName").HasMaxLength(50);
            builder.Property(a => a.LastName).HasColumnName("LastName").HasMaxLength(50);
            builder.Property(a => a.Email).HasColumnName("Email").HasMaxLength(50);
            builder.Property(a => a.PasswordHash).HasColumnName("PasswordHash").HasMaxLength(500);
            builder.Property(a => a.PasswordSalt).HasColumnName("PasswordSalt").HasMaxLength(500);
        }
    }
}
