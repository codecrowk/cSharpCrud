using FiltroCSharp.Mvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiltroCSharp.Mvc
{
  public class JobsController : Controller 
  {
    public readonly BaseContext _context;

    public JobsController (BaseContext context)
    {
      _context = context;
    } 

    public async Task<IActionResult> Index ()
    {
      // return View();
      return View(await _context.Jobs.ToListAsync());
    }
  }
}