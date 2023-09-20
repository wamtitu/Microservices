using Blog_Post.DbConnection;
using Blog_Post.Extensions;
using Blog_Post.Services;
using Blog_Post.Services.IServices;
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

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpClient("Comment", c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrl:CommentApi"]));
builder.Services.AddScoped<ICommentsService, CommentService>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddCors(options => options.AddPolicy("policy1", build =>
{
    build.WithOrigins("http://localhost:5100");
    build.AllowAnyHeader();
    build.AllowAnyMethod();
}));

builder.AddSwaggenGenExtension();
builder.AddAppAuthentication();

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
