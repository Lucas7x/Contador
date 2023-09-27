using Contador.Context;
using Contador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contador.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : Controller
    {
        [HttpGet("Id")]
        public async Task<IActionResult> GetPersonById(long id)
        {
            try
            {
                using var context = new DataContext();
                Person person = await context.Persons.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(new
                {
                    Success = true,
                    Person = person
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            try
            {
                using var context = new DataContext();
                List<Person> persons = await context.Persons.ToListAsync();
                return Ok(new
                {
                    Success = true,
                    Persons = persons
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostPerson(Person person)
        {
            try
            {
                using var context = new DataContext();
                await context.Persons.AddAsync(person);
                await context.SaveChangesAsync();

                return Ok(new
                {
                    Success = true,
                    Person = person,
                    Message = "Pessoa adicionada com sucesso."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}
