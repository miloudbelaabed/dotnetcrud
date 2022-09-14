using System;
using RecipeApp.Enums;

namespace RecipeApp.Entities
{
  public class User
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Profile { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public String About { get; set; }
    public Genre Genre { get; set; }

  }
}