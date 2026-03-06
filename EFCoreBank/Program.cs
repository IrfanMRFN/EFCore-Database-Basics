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

// Create C# Object that represent a row in the db table
Account newAccount = new Account
{
    AccountHolder = "Muhammad Irfan",
    Balance = 1500000m
};

// Tell Entity Framework to track this new object for insertion
dbContext.Accounts.Add(newAccount);

// Generate and execute the SQL INSERT command
await dbContext.SaveChangesAsync();
Console.WriteLine($"Successfully created account for {newAccount.AccountHolder} in the database!");
