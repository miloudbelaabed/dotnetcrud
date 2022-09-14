
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RecipeApp.Entities
{
  public class Categorie
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public virtual IList<Blog> Blogs { get; set; }
  }
}