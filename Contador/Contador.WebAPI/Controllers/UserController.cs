﻿using Contador.Context;
using Contador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contador.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("Id")]
    public async Task<IActionResult> GetUserById(long id)
    {
        try
        {
            using var context = new DataContext();
            User user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(new
            {
                Success = true,
                User = user
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
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            using var context = new DataContext();
            List<User> users = await context.Users.ToListAsync();
            return Ok(new
            {
                Success = true,
                Users = users
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
    public async Task<IActionResult> PostUser(User user)
    {
        try
        {
            using var context = new DataContext();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return Ok(new
            {
                Success = true,
                User = user,
                Message = "Usuário adicionado com sucesso."
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
