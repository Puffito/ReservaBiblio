using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ReservaBiblio.Client;
using ReservaBiblio.Client.Services;
using ReservaBiblio.Client.Providers;
using CurrieTechnologies.Razor.SweetAlert2;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost") });

builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IProfesoresService, ProfesoresService>();
builder.Services.AddScoped<IEspaciosService, EspaciosService>();
builder.Services.AddScoped<IReservasEspaciosService, ReservasEspaciosService>();
builder.Services.AddScoped<IReservasMaterialService, ReservasMaterialService>();

builder.Services.AddSweetAlert2();

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<SessionStorageAccessor>();

await builder.Build().RunAsync();