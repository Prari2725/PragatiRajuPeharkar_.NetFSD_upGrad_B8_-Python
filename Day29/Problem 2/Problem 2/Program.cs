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


//getallcontact
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=ShowContact}")
    .WithStaticAssets();

//getcontactbyId
app.MapControllerRoute(
    name: "getContactById",
    pattern: "Contact/GetContactById/{id}",
    defaults: new { controller = "Contact", action = "GetContactById" });

//AddContact
app.MapControllerRoute(
    name: "addContact",
    pattern: "Contact/AddContact/{id}",
    defaults: new { controller = "Contact", action = "AddContact" });

//Edit
app.MapControllerRoute(
    name:"editContact",
    pattern:"Contact/EditContact/{id}",
    defaults: new {controller="Contact", action="EditContact"});

//delete
app.MapControllerRoute(
    name: "deleteContact",
    pattern: "Contact/DeleteContact/{id}",
    defaults: new { controller = "Contact", action = "DeleteContact" });


app.Run();


