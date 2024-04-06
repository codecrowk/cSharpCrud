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

    public async Task<IActionResult> Update (int Id)
    {
      return View(await _context.Companies.FirstOrDefaultAsync(register => register.Id == Id));
    }

    [HttpPost]
    public IActionResult Update (Company c)
    {
      _context.Companies.Update(c);
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

    // Search
    public IActionResult Search (string searchString)
    {
      var company = _context.Companies.AsQueryable();
      // var users = from user in _context.Companies select user;
      if (!string.IsNullOrEmpty(searchString))
      {
        company = company.Where(c => c.Name.Contains(searchString));
      }

      return View("Search", company.ToList());
    }
  }
}