namespace Contador.Models;

public class User : BaseModel
{
    public long PersonId { get; set; }
    public Person Person { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}