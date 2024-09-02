using Microsoft.EntityFrameworkCore;
using TSM.Issue.Domain;
namespace TSM.Issue.Infrastructure;

public class ProblemContext : DbContext
{
  public ProblemContext(DbContextOptions<ProblemContext> options)
          : base(options)
  {
  }

  public DbSet<Problem> Problems => Set<Problem>();
  public DbSet<Category> Categories => Set<Category>();
  public DbSet<Priority> Priorities => Set<Priority>();
}
