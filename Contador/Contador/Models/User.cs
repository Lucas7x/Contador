namespace Contador.Models;

public class User : BaseModel
{
    public Person Person { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public User(Person person, string login, string password)
    {
        Person = person;
        Login = login;
        Password = password;
    }
}
