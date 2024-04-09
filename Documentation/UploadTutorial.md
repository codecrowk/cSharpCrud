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

// name espace for IFormFile
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


    [HttpPost]
    // Get user form information, upload file and file folder ubication (images, documents...) 
    public async Task<IActionResult> Insert (User user, IFormFile file, int ubication)
    {
      return RedirectToAction("Index");
    }
  }
}
``` 

## 7- Making configuration inside post contoller method

## 8- Update views to allow upload a file



## Notes

#### Helpers and providers are globally avalible 
You can use helpers and providers globally, it means that any controller can use its functionality like BaseContext (connection to database)