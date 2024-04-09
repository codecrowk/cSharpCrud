using Microsoft.EntityFrameworkCore;

namespace FiltroCSharp.Mvc.Data
{
  public class BaseContext : DbContext
  {
   public BaseContext (DbContextOptions <BaseContext> options) : base (options)
   {

   }
  }
}