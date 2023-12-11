using Core.Entities;

namespace Entities.Concretes;

public class Category:Entity<int>
{
    public int Id  { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}