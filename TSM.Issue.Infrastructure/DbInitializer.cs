using TSM.Issue.Domain;
namespace TSM.Issue.Infrastructure;

public static class DbInitializer
{
  public static void Initialize(ProblemContext context)
  {

    if (context.Priorities.Any()
        && context.Categories.Any())
    {
      return;
    }
    var priorities = new Priority[] {
      new Priority { Name = "Blocking" },
      new Priority { Name = "High" },
      new Priority { Name = "Medium" },
      new Priority { Name = "Low" },
    };
    var categories = new Category[] {
      new Category { Name = "ToDo" },
      new Category { Name = "In Progress" },
      new Category { Name = "Done" },
      new Category { Name = "Canceled" },
    };

    context.Priorities.AddRange(priorities);
    context.Categories.AddRange(categories);
    context.SaveChanges();
  }
}
