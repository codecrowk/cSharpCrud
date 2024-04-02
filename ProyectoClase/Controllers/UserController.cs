// You have to make a reference of your DataBase, with project name
using ProyectoClase.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// You have to put the name of your root folder
namespace ProyectoClase.Controllers
{
  public class UserController : Controller
  {
    // Here you are creating a varible that reference Data class (in this case, LibraryUserContext)
    // Readonly only allow to modify a varible inside a constructor
    public readonly LibraryUsersContext _context;

    public UserController (LibraryUsersContext context)
    {
      _context = context;
    } 

    public async Task<IActionResult> Index ()
    {
      return View (await _context.Users.ToListAsync());
      // TolistAsync == select * from users
    }
  }
}