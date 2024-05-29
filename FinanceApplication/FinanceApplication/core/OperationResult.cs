using System;

public class OperationResult
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public bool Profit { get; set; }
    public string Date { get; set; }
    public decimal Sum { get; set; }
    public int WalletId { get; set; }
    public string Cathegory { get; set; }
    public string Description { get; set; }
    public string WalletName { get; set; }
    public string WalletType { get; set; }

    public override string ToString()
    {
        return $"Id {Id} UserId  {UserId} Profit {Profit} Date {Date} Sum {Sum} WalletId {WalletId} Cathegory {Cathegory} Description {Description} WalletName {WalletName} WalletType {WalletType}";
    }
}
