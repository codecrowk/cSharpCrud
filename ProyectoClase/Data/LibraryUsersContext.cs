using Microsoft.EntityFrameworkCore;
// You have to make reference to the models root folder
using ProyectoClase.Models;

namespace ProyectoClase.Data
{
  public class LibraryUsersContext : DbContext
  {
    public LibraryUsersContext(DbContextOptions<LibraryUsersContext> options) : base(options)
    {
    }
    
    // Make reference to model
    // public DbSet<User> <ALIAS> {get; set;} 
    public DbSet<Users> Users {get; set;}
  }
}