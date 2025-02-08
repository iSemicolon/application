using Microsoft.FeatureManagement;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
/*builder.Configuration
.AddAzureAppConfiguration("Endpoint=https://myappconfigdemo.azconfig.io;Id=2kfE;Secret=BPYFaInlrp3q0mChxzUN0NNWovmZc17GPa0SiqkeF1Hvv1JSuTxNJQQJ99BBACYeBjFam5FzAAABAZAC2Nij");*/

builder.Configuration.AddAzureAppConfiguration(
    options=>{
        options.Connect("Endpoint=https://myappconfigdemo.azconfig.io;Id=q+ZN;Secret=BXCTd054mVAYyDSPaGRLz80izXCgQyErbGDL8LqTs1cOwZt7czgGJQQJ99BBAC4f1cMam5FzAAABAZAC2KsY");
        options.UseFeatureFlags();

    }
);

builder.Services.AddFeatureManagement();
/*
builder.Configuration
.AddJsonFile("appsettings.json")
    .AddEnvironmentVariables();
*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
