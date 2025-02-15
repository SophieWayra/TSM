using System.ComponentModel.DataAnnotations;

namespace TSM.Issue.Domain;

public class Priority
{
  public int Id { get; set; }
  
  [Required]
  public string? Name { get; set; }
}
