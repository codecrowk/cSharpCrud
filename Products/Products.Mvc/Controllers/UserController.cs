using Products.Mvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Mvc.Helpers;
using Products.Mvc.Models;
using Microsoft.AspNetCore.Http;
using Products.Mvc.Providers;

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

    public async Task<IActionResult> Detail (int Id)
    {
      // Use FirstOrDefaultAsync is async, intead FirstOrDefault is sincronic
      var data = await _context.Users.FirstOrDefaultAsync(m => m.Id == Id);
      Console.WriteLine(data);
      return View(await _context.Users.FirstOrDefaultAsync(m => m.Id == Id));
    }

    public async Task<IActionResult> Delete (int Id)
    {
      var data = await _context.Users.FirstAsync(register => register.Id == Id);
      Console.WriteLine(data);
      _context.Users.Remove(data);
      _context.SaveChanges();
      // Calls Index method
      return RedirectToAction("Index");
    }

    public IActionResult Create ()
    {
      return View();
    }

    [HttpPost]
    // Get user form information, upload file and file folder ubication (images, documents...) 
    // file and ubication params are going to be fullfiled with form values, names must match
    public async Task<IActionResult> Create (User user, IFormFile file, int ubication)
    {
      string fileName = file.FileName;
      Console.WriteLine(fileName);
      // Reference id intead of filename, make unique image for each user
      // string fileName = user.Id.ToString();

      string path="";

      // This save file in server
      switch (ubication)
      {
        case 0:
          // Send file (img, pdf...), fileName, and destination folder 
          path = await this._helperUploadFiles.UploadFilesAsync(file, fileName, Folders.Uploads);
        break;
        case 1:
          path = await this._helperUploadFiles.UploadFilesAsync(file, fileName, Folders.Images);
        break;
        case 2:
          path = await this._helperUploadFiles.UploadFilesAsync(file, fileName, Folders.Documents);
        break;
        case 3:
          path = await this._helperUploadFiles.UploadFilesAsync(file, fileName, Folders.Temp);
        break;
      }

      // Reference logo with server file name
      user.Logo = fileName;
      // Add user to db
      _context.Users.Add(user);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }
  }
}