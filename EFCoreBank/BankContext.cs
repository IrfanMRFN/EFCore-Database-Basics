using Microsoft.EntityFrameworkCore;

namespace EFCoreBank;

public class BankContext : DbContext
{
    public BankContext(DbContextOptions<BankContext> options) : base(options)
    {
    }

    // DbSet for creating table based on created entity (class)
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}
