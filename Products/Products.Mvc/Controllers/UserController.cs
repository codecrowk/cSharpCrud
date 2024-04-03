using Products.Mvc.Data;
using Microsoft.AspNetCore.Mvc;

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
    public UserController(BaseContext context)
    {
      _context = context;
    }
  }
}