
namespace RecipeApp.Entities
{
  public class Comment
  {
    public int Id { get; set; }
    public string Text { get; set; }
    public int Liked { get; set; }
    public int AuthorId { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
    public User User { get; set; }

  }
}