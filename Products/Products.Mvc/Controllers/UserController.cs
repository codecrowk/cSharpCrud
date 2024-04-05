using Products.Mvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Dont forget plural in Controllers
// namespace <ROOT FOLDER>
namespace Products.Mvc.Controllers
{
  public class UserController : Controller
  {
    // Readonly just allow to be modified inside a constructor
    public readonly BaseContext _context;

    /* This constructor reference a database, it is not using a entity, just making the
    connection */  
    // Basecontext is automatically setup, you don't have to pass a value
    public UserController(BaseContext context)
    {
      _context = context;
    }

    public async Task<IActionResult> Index ()
    {

      return View(await _context.Users.ToListAsync());
    }

    public async Task<IActionResult> Detail (int userId)
    {
      // Use FirstOrDefaultAsync is async, intead FirstOrDefault is sincronic
      var data = await _context.Users.FirstOrDefaultAsync(m => m.Id == userId);
      Console.WriteLine(data);
      return View(await _context.Users.FirstOrDefaultAsync(m => m.Id == userId));
    }

    public async Task<IActionResult> Delete (int userId)
    {
      var data = await _context.Users.FirstAsync(register => register.Id == userId);
      Console.WriteLine(data);
      _context.Users.Remove(data);
      _context.SaveChanges();
      // Calls Index method
      return RedirectToAction("Index");
    }
  }
}