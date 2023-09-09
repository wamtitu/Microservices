using Auth_Blogger.DbConnections;
using Auth_Blogger.Extensions;
using Auth_Blogger.Models;
using Auth_Blogger.Services;
using Auth_Blogger.Services.IServices;
using Auth_Blogger.Utilities;
// using AuthMailingServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyConnection>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("localConnection"));
});
//register identity framework
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MyConnection>();

builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IToken, TokenServices>();
builder.Services.AddScoped<IMessageBus, MessageBusService>();
//Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//configure JWtOptions 
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMigration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
