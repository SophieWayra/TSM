using TSM.Issue.Api;

var app = Host.CreateDefaultBuilder(args)
  .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
  .Build();
app.CreateDbIfNotExists();
await app.RunAsync();