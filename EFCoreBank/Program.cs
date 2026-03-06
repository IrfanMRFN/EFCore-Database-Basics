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
Console.WriteLine("Fetching account from database...");

// READ: Find the first account where the name matches
Account? myAccount = await dbContext.Accounts
    .FirstOrDefaultAsync(a => a.AccountHolder == "Muhammad Irfan");

if (myAccount != null)
{
    Console.WriteLine($"Found Account ID: {myAccount.Id} for {myAccount.AccountHolder}");

    // CREATE: Build a new Transaction object
    Transaction newDeposit = new Transaction
    {
        Amount = 500000m,
        // LINK: Foreign Key that connects this transaction to the specific acount
        AccountId = myAccount.Id
    };

    // UPDATE: Change the account balance in C# memory
    myAccount.Balance += newDeposit.Amount;

    // TRACK: Tell EF Core about the new transaction
    dbContext.Transactions.Add(newDeposit);

    // COMMIT: Push all changes to SQL Server
    await dbContext.SaveChangesAsync();

    Console.WriteLine($"Successfully deposited Rp {newDeposit.Amount}");
    Console.WriteLine($"New Balance is: Rp {myAccount.Balance}");
}
else
{
    Console.WriteLine("Account not found!");
}
