using Microsoft.AspNetCore.Rewrite;
using TSM.Issue.Application;
using TSM.Issue.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace TSM.Issue.Api;

public class Startup
{
  private readonly IWebHostEnvironment _env;

  public Startup(IConfiguration configuration, IWebHostEnvironment env)
  {
    Configuration = configuration;
    _env = env;
  }

  public IConfiguration Configuration { get; }

  public void ConfigureServices(IServiceCollection services)
  {
    services.AddDbContext<ProblemContext>(options =>
    {
      options.UseNpgsql("Host=localhost;Port=5432;Database=TSM;User ID=postgres;Password=12345Qwe!",
        b => b.MigrationsAssembly("TSM.Issue.Api"));
    });
    services.AddScoped<ProblemService>();
    services.AddScoped<PriorityService>();
    services.AddScoped<CategoryService>();
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    
   
  }
  
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }

    app.UseRouting();
    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    var option = new RewriteOptions();
    option.AddRedirect("^$", "swagger");
    app.UseRewriter(option);
  }
}