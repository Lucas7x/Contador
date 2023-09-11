namespace Contador.Models
{
    public class Person : BaseModel
    {
        public string Name { get; set; }
        public string? Cpf { get; set; }

        public Person(string name, string? cpf)
        {
            Name = name;
            Cpf = cpf;
        }
    }
}
