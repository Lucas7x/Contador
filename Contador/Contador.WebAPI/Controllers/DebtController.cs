using Contador.Context;
using Contador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contador.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class DebtController : ControllerBase
{
    [HttpGet("Id")]
    public async Task<IActionResult> GetDebtById(long id)
    {
        try
        {
            using var context = new DataContext();
            Debt debt = await context.Debts.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(new
            {
                Success = true,
                Debt = debt
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
    public async Task<IActionResult> GetDebts()
    {
        try
        {
            using var context = new DataContext();
            List<Debt> debts = await context.Debts.ToListAsync();
            return Ok(new
            {
                Success = true,
                Debts = debts
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
    public async Task<IActionResult> PostDebt(Debt debt)
    {
        try
        {
            using var context = new DataContext();
            await context.Debts.AddAsync(debt);
            await context.SaveChangesAsync();

            return Ok(new
            {
                Success = true,
                Debt = debt,
                Message = "Dívida adicionada com sucesso."
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
