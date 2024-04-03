using Microsoft.EntityFrameworkCore;

// Reference data directory
using Products.Mvc.Data;

// namespace <ROOT NAME>
namespace Products.Mvc.Data
{
  // Match file name
  public class BaseContext : DBContext
  {
    /* 
    CODE EXPLAIN
    
    1- First you call BaseContext Contructor (public BaseContext)
    2- Call a generic DBContextOptions (DBContextOptions<BaseContext> <ALIAS>)
    3- Use an alias for "DBContextOptions<BaseContext>" in this case options
    4- Call parent constructor (base (options))
    */

    public BaseContext(DBContextOptions<BaseContext> options) : base (options)
    { }

    // Register model
    // DBSet = set database
    // DBSet<MODEL> <ALIAS>
    public DbSet<User> Users {get; set}

  }
}