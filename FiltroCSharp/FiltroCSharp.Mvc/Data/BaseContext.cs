using FiltroCSharp.Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FiltroCSharp.Mvc.Data
{
  public class BaseContext : DbContext
  {
   public BaseContext (DbContextOptions <BaseContext> options) : base (options)
   { }

   public DbSet<Job> Jobs {get; set;}
   public DbSet<Employ> Employees {get; set;}
  }
}