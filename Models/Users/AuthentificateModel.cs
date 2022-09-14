using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Models.Users
{
  public class AuthenticateModel
  {
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
  }
}