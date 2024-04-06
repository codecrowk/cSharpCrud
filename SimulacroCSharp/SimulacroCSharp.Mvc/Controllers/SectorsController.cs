using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimulacroCSharp.Mvc.Data;
using SimulacroCSharp.Mvc.Models;

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

    public async Task<IActionResult> Detail (int Id)
    {
      return View(await _context.Sectors.FirstOrDefaultAsync(register => register.Id == Id));
    }

    // Modify data
    public IActionResult Create ()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create (Sector s)
    {
      _context.Sectors.Add(s);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update (int Id)
    {
      return View(await _context.Sectors.FirstOrDefaultAsync(register => register.Id == Id));
    }

    [HttpPost]
    public IActionResult Update (Sector s)
    {
      _context.Sectors.Update(s);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }

    // Delete
    public async Task<IActionResult> Delete (int Id)
    {
      var user = await _context.Sectors.FindAsync(Id);
      _context.Sectors.Remove(user);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }

    // Search
    public IActionResult Search (string searchString)
    {
      var sector = _context.Sectors.AsQueryable();
      // var users = from user in _context.Companies select user;
      if (!string.IsNullOrEmpty(searchString))
      {
        sector = sector.Where(s => s.Name.Contains(searchString));
      }

      return View("Search", sector.ToList());
    }
  }
}