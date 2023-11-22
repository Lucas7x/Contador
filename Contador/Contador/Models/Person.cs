namespace Contador.Models;

public class Person : BaseModel
{
    public string Name { get; set; }
    public string? Cpf { get; set; }
    public string? Phone { get; set; }
    public string? Mail { get; set; }
}