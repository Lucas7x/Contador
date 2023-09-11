using Contador.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contador.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPerson()
        {
            Person person = new Person("Lucas Xavier", "06666000600");

            return Ok(new
            {
                Data = person
            });
        }
    }
}
