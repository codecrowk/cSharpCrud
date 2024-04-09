using Products.Mvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Mvc.Helpers;
using Products.Mvc.Models;
using Microsoft.AspNetCore.Http;

// Dont forget plural in Controllers
// namespace <ROOT FOLDER>
namespace Products.Mvc.Controllers
{
  public class UserController : Controller
  {
    // Readonly just allow to be modified inside a constructor
    public readonly BaseContext _context;
    // Conection to upload files helper
    private readonly HelperUploadFiles _helperUploadFiles;

    /* This constructor reference a database, it is not using a entity, just making the
    connection */  
    // Basecontext is automatically setup, you don't have to pass a value
    public UserController(BaseContext context, HelperUploadFiles helperUpload)
    {
      _context = context;
      // Helper upload is a private property, I think it is necessary to use this to make a reference
      this._helperUploadFiles = helperUpload;
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

    [HttpPost]
    // Get user form information, upload file and file folder ubication (images, documents...) 
    public async Task<IActionResult> Insert (User user, IFormFile file, int ubication)
    {
      string fileName = file.FileName;
      return RedirectToAction("Index");
    }
  }
}