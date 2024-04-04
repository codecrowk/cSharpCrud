// Remember it is a connection between database and model
using Microsoft.EntityFrameworkCore;

// Reference model directory
using Products.Mvc.Models;

// namespace <ROOT NAME>
namespace Products.Mvc.Data
{
  //Match file name
  public class BaseContext : DbContext
  {
    /* 
    CODE EXPLAIN
    
    1- First you call BaseContext Contructor (public BaseContext)
    2- Call a generic DBContextOptions (DBContextOptions<BaseContext> <ALIAS>)
    3- Use an alias for "DBContextOptions<BaseContext>" in this case options
    4- Call parent constructor (base (options))
    */

    public BaseContext(DbContextOptions<BaseContext> options) : base (options)
    { }

    // Register model
    // DBSet = set database
    // DBSet<MODEL> <DATABASE TABLE>
    public DbSet<User> Users {get; set;}

  }
}