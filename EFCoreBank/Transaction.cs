namespace EFCoreBank;

public class Transaction
{
    // Primary Key
    // EF Core automatically makes properties named 'Id' the Primary Key
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign Key
    public int AccountId { get; set; }

    // Navigation Property
    // The 'null!' tells the compiler that EF Core will populate this later
    public Account Account { get; set; } = null!;
}
