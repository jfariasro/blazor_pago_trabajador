using AppWebBlazor2.Client;
using AppWebBlazor2.Client.Services.Entities;
using AppWebBlazor2.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ICargoService, CargoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

await builder.Build().RunAsync();
