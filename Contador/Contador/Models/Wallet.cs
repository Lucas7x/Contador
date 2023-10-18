
namespace Contador.Models
{
    public class Wallet
    {
        public string Name {  get; set; }
        public float Balance { get; set; }
        public Person person { get; set; }
        
        public void Deposito (float value )
        {
            Balance = Balance + value;
            
        }
        
        public bool Saque(float value) {
            if (value > Balance) return false;
            else {
                
                Balance = Balance - value;
                return true; 
            }
        }
    }
}