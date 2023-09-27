using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//ocelot Configuration
if (builder.Environment.EnvironmentName.ToString().ToLower().Equals("production"))
{
    builder.Configuration.AddJsonFile("Ocelot.Production.json", optional: false, reloadOnChange: true);
}
else
{
    builder.Configuration.AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true);
}
builder.Services.AddOcelot(builder.Configuration);

//cors
builder.Services.AddCors(options => options.AddPolicy("policy1", build =>
{
  
    build.AllowAnyOrigin();
    build.AllowAnyHeader();
    build.AllowAnyMethod();
}));
var app = builder.Build();

app.UseCors("policy1");

app.MapGet("/", () => "Hello World!");
app.UseOcelot().GetAwaiter().GetResult();

app.Run();
