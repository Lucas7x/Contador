using Contador.Context;
using Contador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contador.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("Id")]
        public async Task<IActionResult> GetPersonById(long id)
        {
            try
            {
                using var context = new DataContext();
                Person person = await context.Persons.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            using var context = new DataContext();
            List<Person> persons = await context.Persons.ToListAsync();
            return Ok(new
            {
                Persons = persons
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostPersonAsync(Person person)
        {
            try
            {
                using var context = new DataContext();
                await context.Persons.AddAsync(person);
                await context.SaveChangesAsync();

                return Ok(new
                {
                    Success = true,
                    Message = "Pessoa adicionada com sucesso."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
