using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimulacroCSharp.Mvc.Data;
using SimulacroCSharp.Mvc.Models;

namespace SimulacroCSharp.Mvc.Controllers 
{
  public class CompaniesController : Controller
  {
    public readonly BaseContext _context;

    public CompaniesController (BaseContext context)
    {
      _context = context;
    }

    public async Task<IActionResult> Index ()
    {
      return View(await _context.Companies.ToListAsync());
    }

    public async Task<IActionResult> Detail (int Id)
    {
      return View(await _context.Companies.FirstOrDefaultAsync(register => register.Id == Id));
    }

    // Modify data
    public IActionResult Create ()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create (Company c)
    {
      _context.Companies.Add(c);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
    // Delete
    public async Task<IActionResult> Delete (int Id)
    {
      var user = await _context.Companies.FindAsync(Id);
      _context.Companies.Remove(user);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}