using Microsoft.AspNetCore.Mvc.Razor;
using Val.Hackathon.Signaling.Room;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddMvc(x =>
{
    x.EnableEndpointRouting = false;
});

builder.Services.AddSignalR(x =>
{
    x.EnableDetailedErrors = true;
});

builder.Services.Configure<RazorViewEngineOptions>(razor =>
{
    razor.ViewLocationFormats.Add("/Signaling/{1}/{0}" + RazorViewEngine.ViewExtension);
    razor.ViewLocationFormats.Add("/{1}/{0}" + RazorViewEngine.ViewExtension);
});

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

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
app.UseMvc();
app.UseMvcWithDefaultRoute();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapHub<RoomHub>("/meet", r =>
    {

    });
});

app.Run();
