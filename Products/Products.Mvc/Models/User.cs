namespace Products.Mvc.Models
{
  // You create the structure base in database attributes
  public class User
  {
    // Get / Set are used for allow reading (get) and writing (set)
    public int? Id {get; set;}
    public string? Name {get; set;}
    public string? Lastname {get; set;}
    public string? Email {get; set;}

    public string? Logo {get; set;}
  }
}