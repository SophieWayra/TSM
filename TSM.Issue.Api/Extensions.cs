using TSM.Issue.Infrastructure;

namespace TSM.Issue.Api;

public static class Extensions
{
  public static void CreateDbIfNotExists(this IHost host)
  {
    {
      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ProblemContext>();
        context.Database.EnsureCreated();
        DbInitializer.Initialize(context);
      }
    }
  }
}