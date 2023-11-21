var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
// builder.Services.AddRazorPages();

builder.Services.LoadAssembly("XmuAuthen");
builder.Services.LoadAssembly("UserStores");
builder.Services.ScanAllDependency();
builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddSqliteDatabase(@"./myDb.db", "DotNetExp");//启动项目的名称


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
