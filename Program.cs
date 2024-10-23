var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register HttpClient and JokeService
builder.Services.AddHttpClient();
builder.Services.AddScoped<MyMvcApp.Services.JokeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Set the default controller route to Joke
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Joke}/{action=Index}/{id?}");

app.Run();
