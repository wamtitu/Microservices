using Blog_Comments.DbConnection;
using Blog_Comments.Extensions;
using Blog_Comments.Services;
using Blog_Comments.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppConnection>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("localConnection"));
});

 builder.Services.AddScoped<ICommentService, CommentService>();
//registering automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.AddSwaggenGenExtension();
builder.AddAppAuthentication();
builder.Services.AddCors(options => options.AddPolicy("policy1", build =>
{
    build.WithOrigins("http://localhost:5100");
    build.AllowAnyHeader();
    build.AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMigration();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors("policy1");

app.Run();
