using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimulacroCSharp.Mvc.Data;

namespace SimulacroCSharp.Mvc.Controllers 
{
  public class SectorsController : Controller
  {
    public readonly BaseContext _context;

    public SectorsController (BaseContext context)
    {
      _context = context;
    }

    public async Task<IActionResult> Index ()
    {
      return View(await _context.Sectors.ToListAsync());
    }

  }
}