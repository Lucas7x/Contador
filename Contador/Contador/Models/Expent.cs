namespace Contador.Models
{
    public class Expent : BaseModel
    {
        public string Descricao { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public Category? Category { get; set; }

        public Expent(string descricao, decimal value, DateTime date, Category? category)
        {
            Descricao = descricao;
            Value = value;
            Date = date;
            Category = category;
        }
    }
}
