using Contador.Context;
using Contador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Contador.WebAPI.Controllers;

[Route("api/[Controller]/[action]")]
[Controller]
public class CategoryController : Controller
{
    [HttpGet("Id")]
    public async Task<IActionResult> GetCategoryById(long id)
    {
        try
        {
            using var context = new DataContext();
            Category category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
                throw new Exception("A categoria buscada não foi encontrada.");

            return Ok(new
            {
                Success = true,
                Category = category,
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

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        try
        {
            using var context = new DataContext();
            List<Category> categories = await context.Categories.ToListAsync();
            return Ok(new
            {
                Success = true,
                Categories = categories
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
    public async Task<IActionResult> PostCategory(Category category)
    {
        try
        {
            using var context = new DataContext();
            context.Categories.Add(category);
            await context.SaveChangesAsync();

            return Ok(new
            {
                Success = true,
                Category = category,
                Message = "Categoria adicionada com sucesso"
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
