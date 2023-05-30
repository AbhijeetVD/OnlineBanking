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
                .HasKey(a => a.AccountNumber);
            modelBuilder.Entity<Transaction>()
                .HasKey(a => a.TransactionId);
            modelBuilder.Entity<User>()
                .HasKey(a => a.UserId);
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Transactions)
                .WithOne(t => t.Account)
                .HasForeignKey(t => t.AccountNumber);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Account)
                .WithOne(a => a.User)
                .HasForeignKey<User>(a => a.UserId);
            modelBuilder.Entity<Account>()
                .HasOne(a => a.User)
                .WithOne(u => u.Account)
                .HasForeignKey<User>(u => u.AccountNumber);
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired();
            modelBuilder.Entity<User>()
            .Property(u => u.FullName)
                .IsRequired();
            modelBuilder.Entity<Account>()
                .Property(a => a.AccountType)
                .IsRequired();
        }
    }
}
