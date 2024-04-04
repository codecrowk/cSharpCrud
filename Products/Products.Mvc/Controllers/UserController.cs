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
  }
}