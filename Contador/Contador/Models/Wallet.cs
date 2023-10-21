
namespace Contador.Models;

public class Wallet : BaseModel
{
    public string Name {  get; set; }
    public float Balance { get; set; }
    public Person person { get; set; }
    
    public void Deposit (float value )
    {
        Balance = Balance + value;
    }
    
    public bool Withdraw(float value) {
        if (value > Balance) 
            return false;
        else 
        {
            Balance = Balance - value;
            return true; 
        }
    }
}