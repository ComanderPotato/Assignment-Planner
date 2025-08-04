global using Microsoft.AspNetCore.Components.Authorization;
using Assignment_2.Client;
using Assignment_2.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});
builder.Services.AddRouting();
builder.Services.AddScoped<IUserService, ClientUserService>();
builder.Services.AddScoped<ITaskItemService, ClientTaskItemService>();
builder.Services.AddScoped<AuthenticationStateProvider, ApplicationAuthStateProviders>();
await builder.Build().RunAsync();
