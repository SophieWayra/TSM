using System.ComponentModel.DataAnnotations;

namespace TSM.Issue.Domain;

public class Problem
{
  public int Id { get; set; }
  
  [Required]
  public string? Name { get; set; }

  public string? Description { get; set; }

  [Required]
  public Category? Category { get; set; }

  [Required]
  public Priority? Priority { get; set; }

  [Required]
  public DateTime? CreationDate { get; set; }
  
  [Required]
  public DateTime? DueDate { get; set; } 
}

public class ProblemListView
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Description { get; set; }
  public string? Category { get; set; }
  public string? Priority { get; set; }
  public DateTime? CreationDate { get; set; }
  public DateTime? DueDate { get; set; } 
}

public class ProblemCreate
{
  public string? Name { get; set; }
  public string? Description { get; set; }
  public int? CategoryId { get; set; }
  public int? PriorityId { get; set; }
  public DateTime? DueDate { get; set; } 
}