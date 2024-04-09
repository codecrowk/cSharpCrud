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

    // Method to search user
    public async Task<IActionResult> Index (string search)
    {
      var jobSearch = _context.Jobs.AsQueryable();
      if (!string.IsNullOrEmpty(search))
      {
        jobSearch = jobSearch.Where(result => 
            result.Id.ToString().Contains(search) ||
            result.NameCompany.Contains(search) ||
            result.OfferTitle.Contains(search) ||
            result.Description.Contains(search) ||
            result.Salary.ToString().Contains(search) ||
            result.Country.Contains(search) ||
            result.Languages.Contains(search)
          );
      }
      return View(await jobSearch.OrderByDescending(j => j.Salary).ToListAsync());
    }


    public async Task<IActionResult> Detail (int Id)
    {
      return View(await _context.Jobs.FirstOrDefaultAsync(r => r.Id == Id));
    }

    //----- UPDATE ----- //
    public async Task<IActionResult> Update (int Id)
    {
      return View(await _context.Jobs.FirstOrDefaultAsync(r => r.Id == Id));
    }

    [HttpPost]
    public async Task<IActionResult> Update (Job job, IFormFile file)
    {
      string fileName = file.FileName;
      await this._helperUploadFiles.UploadFilesAsync(file, fileName, Folders.Images);

      job.LogoCompany = fileName;
      _context.Jobs.Update(job);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    //----- CREATE ----- //
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

    public async Task<IActionResult> Delete (int Id)
    {
      var job = await _context.Jobs.FindAsync(Id);
      _context.Jobs.Remove(job);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}