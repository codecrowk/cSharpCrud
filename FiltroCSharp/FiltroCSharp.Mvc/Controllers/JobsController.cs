using FiltroCSharp.Mvc.Data;
using FiltroCSharp.Mvc.Helpers;
using FiltroCSharp.Mvc.Models;
using FiltroCSharp.Mvc.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiltroCSharp.Mvc
{
  public class JobsController : Controller 
  {
    public readonly BaseContext _context;
    private readonly HelperUploadFiles _helperUploadFiles;

    public JobsController (BaseContext context, HelperUploadFiles helperUpload)
    {
      _context = context;
      this._helperUploadFiles = helperUpload;
    } 

    public async Task<IActionResult> Index ()
    {
      return View(await _context.Jobs.ToListAsync());
    }

    public IActionResult Create ()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create (Job job, IFormFile file)
    {
      string fileName = file.FileName;

      await this._helperUploadFiles.UploadFilesAsync(file, fileName, Folders.Images);
      job.LogoCompany = fileName;

      _context.Jobs.Add(job);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }
  }
}