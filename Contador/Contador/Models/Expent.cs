namespace Contador.Models;

public class Expent : BaseModel
{
    public string Description { get; set; }
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public Category? Category { get; set; }
    
    public Expent(string description, decimal value, DateTime date, Category? category)
    {
        Description = description;
        Value = value;
        Date = date;
        Category = category;
    }
}
