using System.ComponentModel.DataAnnotations;
using RecipeApp.Entities;

namespace RecipeApp.Models.Diplomes
{
  public class DiplomeModel
  {
    [Key]
    public string CodeDiplome { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public string Intitule { get; set; }
    public int SpecialiteId { get; set; }


  }
}
