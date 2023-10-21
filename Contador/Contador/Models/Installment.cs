using Contador.Models.Enums;
using Contador.Models.Interfaces;

namespace Contador.Models;

public class Installment : BaseModel, IPayable
{
    public Debt Debt { get; set; }
    public double Value { get; set; }
    public DateTime DueDate { get; set; }
    public InstallmentStatus Status { get; set; }
}