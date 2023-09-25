using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blog_X;
using Blog_X.Services.Posts;
using Blog_X.Services.Comments;
using Blog_X.Services.Authentication;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Blog_X.Services.AuthProvider;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPostInterface, PostService>();
builder.Services.AddScoped<IAuthInteface, AuthService>();
builder.Services.AddScoped<ICommentInterface, CommentService>();

//Configuration for AuthProvider
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
