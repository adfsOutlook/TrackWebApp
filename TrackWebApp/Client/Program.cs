using Project.Client;
using Project.Client.Helpers;
using Project.Client.Repositorios;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Project.Client.Services;
using Syncfusion.Blazor;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//builder.Services.AddHttpClient("Project.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
//    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();


builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Project.ServerAPI"));







builder.Services.AddIdentityCore<IdentityUser>();


builder.Services.AddScoped<IRepositorio, Repositorio>();
builder.Services.AddScoped<IMostrarMensajes, MostrarMensajes>();
builder.Services.AddScoped<ILocalStorageManager, LocalStorageManager>();
builder.Services.AddScoped<BrowserService>();

builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXZccXZUQ2ReVkdwW0Q=");
builder.Services.AddSyncfusionBlazor();


await builder.Build().RunAsync();

