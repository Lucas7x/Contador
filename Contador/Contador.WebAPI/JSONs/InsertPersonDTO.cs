namespace Contador.WebAPI.JSONs;

public class InsertPersonDTO
{
    public string Name { get; set; }
    public string? Cpf { get; set; } = null;
    public string? Phone { get; set; }
    public string? Mail { get; set; }
}
