namespace Contador.Models;

public class Debt : BaseModel
{
    public string Description { get; set; }
    public double Value { get; set; }
    public DateTime Date { get; set; }
}
