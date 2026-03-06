using EFCoreBank;
using Microsoft.EntityFrameworkCore;

// Setup SQL Server connection string
string connectionString = "Server=localhost;Database=EFCoreBankDb;Trusted_Connection=True;TrustServerCertificate=True;";

// Configure the DbContext Options
var optionsBuilder = new DbContextOptionsBuilder<BankContext>();
optionsBuilder.UseSqlServer(connectionString);

// Open the database session
// Instantiate the context inside a 'using' statement so it safely closes the connection when done
using var dbContext = new BankContext(optionsBuilder.Options);
Console.WriteLine("Connected to SQL Server!");
Console.WriteLine("Fetching account and transaction history... \n");

// READ WITH RELATIONS (Eager Loading)
Account? myAccount = await dbContext.Accounts
    .Include(a => a.Transactions)
    .FirstOrDefaultAsync(a => a.AccountHolder == "Muhammad Irfan");

if (myAccount != null)
{
    Console.WriteLine("========================");
    Console.WriteLine($" ACCOUNT STATEMENT FOR: {myAccount.AccountHolder}");
    Console.WriteLine($" ACCOUNT ID: {myAccount.Id}");
    Console.WriteLine($" CURRENT BALANCE: Rp {myAccount.Balance}");
    Console.WriteLine("========================\n");

    Console.WriteLine("--- TRANSACTION HISTORY ---");

    if (myAccount.Transactions.Count == 0)
    {
        Console.WriteLine("No transactions found.");
    }
    else
    {
        foreach (Transaction tx in myAccount.Transactions)
        {
            // Using date formatting 'g'
            Console.WriteLine($"[{tx.CreatedAt:g}] Transaction ID: {tx.Id} | Amount: Rp {tx.Amount}");
        }
    }
    Console.WriteLine("========================");
}
else
{
    Console.WriteLine("Account not found!");
}
