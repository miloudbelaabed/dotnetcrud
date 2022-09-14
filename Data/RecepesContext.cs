using Microsoft.EntityFrameworkCore;
using RecipeApp.Models;
using Microsoft.Extensions.Configuration;
using System;
using RecipeApp.Entities;


namespace RecipeApp.Data
{
  // Todo : connecting to the database;
  public class RecipesContext : DbContext
  {

    public DbSet<User> Users { get; set; }
    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Categorie> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public RecipesContext(DbContextOptions<RecipesContext> options)
    : base(options)
    { }
  }

}
