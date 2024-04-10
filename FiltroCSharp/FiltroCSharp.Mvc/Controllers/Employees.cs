using FiltroCSharp.Mvc.Data;
using FiltroCSharp.Mvc.Helpers;
using FiltroCSharp.Mvc.Models;
using FiltroCSharp.Mvc.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiltroCSharp.Mvc
{
  public class EmployeesController : Controller 
  {
    public readonly BaseContext _context;
    private readonly HelperUploadFiles _helperUploadFiles;

    public EmployeesController (BaseContext context, HelperUploadFiles helperUpload)
    {
      _context = context;
      this._helperUploadFiles = helperUpload;
    } 

    // Method to search user
    public async Task<IActionResult> Index (string search)
    {
      var employSearch = _context.Employees.AsQueryable();
      if (!string.IsNullOrEmpty(search))
      {
        employSearch = employSearch.Where(result => 
            result.Id.ToString().Contains(search) ||
            result.Names.Contains(search) ||
            result.LastNames.Contains(search) ||
            result.Email.Contains(search) ||
            result.Gender.Contains(search) ||
            result.Phone.Contains(search) ||
            result.Address.Contains(search) ||
            result.CivilStatus.Contains(search) ||
            result.About.Contains(search) ||
            result.AcademicTitle.Contains(search) ||
            result.Languages.Contains(search) ||
            result.Area.Contains(search) ||

            result.Salary.ToString().Contains(search) ||
            result.BirthDate.ToString().Contains(search)
          );
      }
      return View(await employSearch.OrderByDescending(j => j.Salary).ToListAsync());
    }


    // public async Task<IActionResult> Detail (int Id)
    // {
    //   return View(await _context.Jobs.FirstOrDefaultAsync(r => r.Id == Id));
    // }

    // //----- UPDATE ----- //
    // public async Task<IActionResult> Update (int Id)
    // {
    //   return View(await _context.Jobs.FirstOrDefaultAsync(r => r.Id == Id));
    // }

    // [HttpPost]
    // public async Task<IActionResult> Update (Job job, IFormFile file)
    // {
    //   string fileName = file.FileName;
    //   await this._helperUploadFiles.UploadFilesAsync(file, fileName, Folders.Images);

    //   job.LogoCompany = fileName;
    //   _context.Jobs.Update(job);
    //   await _context.SaveChangesAsync();
    //   return RedirectToAction("Index");
    // }

    //----- CREATE ----- //
    public IActionResult Create ()
    {
      return View();
    }

    // file = cv.pdf
    // image = profile.img
    [HttpPost]
    public async Task<IActionResult> Create (Employ employ, IFormFile image, IFormFile file,DateOnly date)
    {
      string imageName = image.FileName;
      string fileName = file.FileName;

      await this._helperUploadFiles.UploadFilesAsync(image, imageName, Folders.Images);
      await this._helperUploadFiles.UploadFilesAsync(file, fileName, Folders.Documents);

      employ.BirthDate = date;
      employ.Cv = fileName;
      employ.ProfilePicture = imageName;
      _context.Employees.Add(employ);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete (int Id)
    {
      var employ = await _context.Employees.FindAsync(Id);
      _context.Employees.Remove(employ);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}