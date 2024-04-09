using FiltroCSharp.Mvc.Data;
using Microsoft.AspNetCore.Mvc;

namespace FiltroCSharp.Mvc
{
  public class JobsController : Controller 
  {
    public readonly BaseContext _context;

    public JobsController (BaseContext context)
    {
      _context = context;
    } 
  }
}