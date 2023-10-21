namespace Contador.Models;

public class Installment : BaseModel
{
    public Debt Debt { get; set; }
    public double Value { get; set; }
    public DateTime DueDate { get; set; }
}
