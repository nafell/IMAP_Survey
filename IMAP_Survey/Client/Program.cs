using Blazored.LocalStorage;
using IMAP_Survey.Client;
using IMAP_Survey.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("IMAP_Survey.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)); builder.Services.AddSyncfusionBlazor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<PostService>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("IMAP_Survey.ServerAPI"));

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(ApiKeys.Syncfusion);

await builder.Build().RunAsync();
