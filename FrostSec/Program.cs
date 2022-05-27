using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR().AddAzureSignalR(opt => opt.ConnectionString = "Endpoint=https://frostsecsignalr.service.signalr.net;AccessKey=0uIDDBm7v3iUrQ9Dz4SmmyI0v3k+9xk0uVuk/wb5ffM=;Version=1.0;");
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
app.UseWebSockets();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
