using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true);

builder.Services.AddOcelot().AddCacheManager(sett => sett.WithDictionaryHandle());

var app = builder.Build();

app.UseRouting();

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello World");
});

await app.UseOcelot();
app.Run();
