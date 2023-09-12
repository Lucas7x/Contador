namespace Contador.Models
{
    public class Person : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Cpf { get; set; } = string.Empty;

        public Person(string name, string? cpf)
        {
            Name = name;
            Cpf = cpf;
        }
    }
}
