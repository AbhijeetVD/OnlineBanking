using Microsoft.EntityFrameworkCore;
using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(a => a.User)
                .WithMany(u => u.Accounts);
            modelBuilder.Entity<Transaction>()
                .HasOne(a => a.Account)
                .WithMany(u => u.Transactions);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Accounts)
                .WithOne(a => a.User);        
        }
    }
}
