using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Core.Entities;
using OnlineLibrary.Core.Utilities.Configuration;
using OnlineLibrary.Entities.Concrete;

namespace OnlineLibrary.DataAccess.Concrete.EntityFramework.Contexts
{
    public class OnlineLibraryContext : DbContext
    {
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CoreConfig.GetConnectionString("Default"));
        }
    }
}
