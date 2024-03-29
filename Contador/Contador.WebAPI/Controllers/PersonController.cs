﻿using Contador.Context;
using Contador.Models;
using Contador.WebAPI.JSONs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contador.WebAPI.Controllers;

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

            if (person == null)
                throw new Exception("A pessoa buscada não foi encontrada.");

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
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Success = false,
                Message = ex.Message
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostPerson(InsertPersonDTO personDTO)
    {
        try
        {
            Person person = new Person()
            {
                Name = personDTO.Name,
                Cpf = personDTO.Cpf,
                Phone = personDTO.Phone,
                Mail = personDTO.Mail
            };

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
