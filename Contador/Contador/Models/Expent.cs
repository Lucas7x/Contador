namespace Contador.Models
{
    public class Expent : BaseModel
    {
        public string Descricao { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }

    }
}
