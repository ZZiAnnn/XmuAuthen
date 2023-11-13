var builder = WebApplication.CreateBuilder(args);
// ²âÊÔ¼Ó¸ö×¢ÊÍ
// Add services to the container. 
// builder.Services.AddRazorPages();

builder.Services.LoadAssembly("UserStores");

builder.Services.ScanAllDependency();

builder.Services.AddMvc();

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

// app.UseAuthorization();

// app.MapRazorPages();

app.MapControllers();

app.Run();
