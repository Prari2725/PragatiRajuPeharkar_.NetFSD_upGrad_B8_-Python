var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
     //ViewData
     //pattern: "{controller=Student}/{action=StudentDetails}")
     //ViewBag
     //pattern: "{controller=Student}/{action=s1}")
     //Strongly Typed View
     //pattern: "{controller=Student}/{action=s2}")
     //ViewModel
     //pattern: "{controller=Student}/{action=s3}")
     //TempData
     pattern: "{controller=Student}/{action=s4}")

    .WithStaticAssets();


app.Run();
