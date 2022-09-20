namespace AllSpice.Models
{
  public class Step
  {
    public int Id { get; set; }
    public int Position { get; set; }
    public string Body { get; set; }
    public int RecipeId { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
  }
}