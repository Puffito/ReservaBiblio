using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ReservaBiblio.Client;
using ReservaBiblio.Client.Services;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5037") });

builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IProfesoresService, ProfesoresService>();
builder.Services.AddScoped<IEspaciosService, EspaciosService>();
builder.Services.AddScoped<IReservasEspaciosService, ReservasEspaciosService>();
builder.Services.AddScoped<IReservasMaterialService, ReservasMaterialService>();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
