using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR().AddAzureSignalR(opt => opt.ConnectionString = "Endpoint=https://frostsec.service.signalr.net;AccessKey=ymzv6pm7xK384CDKPU2oLFDM9UwHOkhZcJh6i8TebvQ=;Version=1.0;");
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
app.UseEndpoints(ep =>
{
    //ep.MapHub<ChatHub>("/chat");
});
app.UseWebSockets();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
