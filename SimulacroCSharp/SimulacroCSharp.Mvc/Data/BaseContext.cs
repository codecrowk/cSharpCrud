using Microsoft.EntityFrameworkCore;
using SimulacroCSharp.Mvc.Models;

namespace SimulacroCSharp.Mvc.Data
{
  public class BaseContext : DbContext
  {
    public BaseContext (DbContextOptions <BaseContext> options) : base (options)
    { } 

    // Reference model and database entity
    public DbSet<Company> Companies {get; set;}
    public DbSet<Sector> Sectors {get; set;}
  }
}