using System;
using System.Collections.Generic;
namespace RecipeApp.Entities
{
  public class Blog
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Excerpt { get; set; }
    public string Mtitle { get; set; }
    public string Mdesc { get; set; }
    public string Photo { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public User Author { get; set; }
    public int AuthorId { get; set; }
    public virtual IList<Categorie> Categories { get; set; }
    public virtual IList<Tag> Tags { get; set; }
    public virtual IList<Comment> Comments { get; set; }
  }
}
