using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RecipeApp.Enums;
namespace RecipeApp.Models.Users
{
  public class UserModel
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public Genre Genre { get; set; }
  }
}