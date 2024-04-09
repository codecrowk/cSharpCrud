## 1- Create tree strcuture

#### Folders
Create a folder called `Helpers`, annother one called `Providers`

```sh
mkdir Helpers
mkdir Providers 
```

#### Files
Inside helpers create `HelperUploadFiles.cs`
Inside Providers create `PathProvider.cs`

```sh
touch Helpers/HelperUploadFiles.cs
touch Providers/PathProvider.cs
```

## 2- Create helper structure
```cs
using Products.Mvc.Providers;

namespace Products.Mvc.Helpers
{
    public class HelperUploadFiles
    {
        private PathProvider pathProvider;

        public HelperUploadFiles(PathProvider pathProvider)
        {
            this.pathProvider = pathProvider;
        }

        public async Task<String> UploadFilesAsync(IFormFile formFile, string nombreImagen, Folders folder)
        {
            string path = this.pathProvider.MapPath(nombreImagen, folder);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return path;
        }
    }
}
```

## 3- Create provider structure
```cs
namespace Products.Mvc.Providers
{
    public enum Folders
    {
        Uploads = 0, Images = 1, Documents = 2, Temp = 3
    }

    public class PathProvider
    {
        private IWebHostEnvironment hostEnvironment;

        public PathProvider(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        public string MapPath(string fileName, Folders folder)
        {
            string carpeta = "";

            if (folder == Folders.Uploads)
            {
                carpeta = "uploads";
            }
            else if (folder == Folders.Images)
            {
                carpeta = "images";
            }
            else if (folder == Folders.Documents)
            {
                carpeta = "documents";
            }

            string path = Path.Combine(this.hostEnvironment.WebRootPath, carpeta, fileName);

            if (folder == Folders.Temp)
            {
                path = Path.Combine(Path.GetTempPath(), fileName);
            }

            return path;
        }
    }
}
```

## 4- Configuration of program
```cs
// Service for Helper and Provider
builder.Services.AddSingleton<HelperUploadFiles>();
builder.Services.AddSingleton<PathProvider>();
```

## 5- Create tree structure in wwwroot
```bash
## Temp folder isn't necessary to create, because PathProvider will create it

mkdir wwwroot/images
mkdir wwwroot/documents
mkdir wwwroot/uploads
```

## 6- Basic upload controller structure
```cs
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

    public IActionResult Create ()
    {
      return View();
    }

    [HttpPost]
    // Get user form information, upload file and file folder ubication (images, documents...) 
    // file and ubication params are going to be fullfiled with form values, names must match
    public async Task<IActionResult> Create (User user, IFormFile file, int ubication)
    {
      return RedirectToAction("Index");
    }
  }
}
``` 

## 7- Update create views to allow upload a file

```cs
@model User

<h1>Create user</h1>

@* asp-action= <CONTROLER> method="post" enctype="multipart/form-data" *@
@* enctype - Allow to upload files to server *@

<form asp-action="Create" method="post" enctype="multipart/form-data">
  <div class="mb-3">
    <div class="form-group">
        <label for="">Name:</label>
        <input asp-for="Name" class="form-control">
    </div>

    <div class="form-group">
        <label for="">Lastname:</label>
        <input asp-for="Lastname" class="form-control">
    </div>

    <div class="form-group">
        <label for="">Email:</label>
        <input asp-for="Email" class="form-control">
    </div>
  </div>

  <div class="row">
    <div class="col-md-6">
      <label for="">Ubicacion:</label>
      @* Value for controller, fill param ubication *@
      <select name="ubication" id="" class="form-select">
        <option value="1">Imagenes</option>
        <option value="2">Documentos</option>
        <option value="0">Descargas</option>
        <option value="3">Temporal</option>
      </select>
    </div>

    <div class="col-md-6">
      <div class="form-group">
        <label asp-for="Logo"></label>
      @* Value for create controller, fill param file *@
        <input type="file" name="file" class="form-control">
      </div>
    </div>
  </div>

  <button type="submit" class="btn btn-primary">Submit</button>
</form>
```

## Match create views names with controller params
Params must match with views input `name label` , it means that if you want to pass a file 
and you call name input `file`, you have to use `file` in controller params

```cs
// Name and param must match
<input type="file" name="file" class="form-control">

public async Task<IActionResult> Create (User user, IFormFile file, int ubication)
{
  string fileName = file.FileName;
  return RedirectToAction("Index");
}
```

## 8- Make configuration inside post contoller method
```cs
public async Task<IActionResult> Create (User user, IFormFile file, int ubication)
{
    string fileName = file.FileName;
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
```

## 9- Update index view to load server images
```cs
// Reference path and image name
<td><img src="~/images/@user.Logo" alt="@user.Logo"></td>
```

## Notes

#### Helpers and providers are globally avalible 
You can use helpers and providers globally, it means that any controller can use its functionality like BaseContext (connection to database)