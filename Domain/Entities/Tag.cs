using System.Collections.Generic;
namespace RecipeApp.Entities
{
  public class Tag
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public virtual IList<Blog> Blogs { get; set; }
  }
}