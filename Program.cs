using FluentValidation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WAAI;
using WAAI.Features.Wizard.Steps.Personal;
using WAAI.Features.Wizard.Steps.Account;
using WAAI.Features.Wizard.Steps.Preferences;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IValidator<PersonalInfo>, PersonalInfoValidator>();
builder.Services.AddSingleton<IValidator<AccountInfo>, AccountInfoValidator>();
builder.Services.AddSingleton<IValidator<PreferencesInfo>, PreferencesInfoValidator>();

await builder.Build().RunAsync();