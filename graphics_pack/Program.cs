using graphics_pack.Models;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IShapeList, ShapeList>();
var app = builder.Build();


app.UseRouting();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/")
    .WithStaticAssets();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(
        app.Environment.ContentRootPath, "wwwroot", "assets", "imgs")),
    RequestPath = "/imgs"
});
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/Draw/{*catchall}", "/Draw/Main");
app.Run();
