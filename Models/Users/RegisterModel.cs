using System;

using System.ComponentModel.DataAnnotations;

using RecipeApp.Enums;

namespace RecipeApp.Models.Users
{
  public class RegisterModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Password { get; set; }
    public String About { get; set; }
    public Genre Genre { get; set; }
  }
}