using Contador.Models.Enums;
using Contador.Models.Interfaces;

namespace Contador.Models;

public class MoneyTransfer : BaseModel
{
    public IPayable? Payable { get; set; }
    public double Amount { get; set; }
    public MoneyTransferType Type { get; set; }
    public string Description { get; set; }
    public Wallet? OriginWallet { get; set; }
    public Wallet? DestinationWallet { get; set; }
}