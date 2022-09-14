
using System.Text.Json.Serialization;

namespace RecipeApp.Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]

  public enum Genre
  {
    Male,
    Female,
    NotSpecified
  }
}