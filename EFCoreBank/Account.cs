namespace EFCoreBank;

public class Account
{
    // Primary Key
    public int Id { get; set; }
    public required string AccountHolder { get; set; }
    public decimal Balance { get; set; }

    // Navigation Property
    // One Account has Many Transactions
    public List<Transaction> Transactions { get; set; } = [];
}
