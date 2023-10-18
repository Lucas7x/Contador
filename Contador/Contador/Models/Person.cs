namespace Contador.Models;

public class Person : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string? Cpf { get; set; } = string.Empty;
    public string? Phone { get; set; } = string.Empty;
    public string? Mail { get; set; }
}