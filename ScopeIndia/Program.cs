using Microsoft.EntityFrameworkCore;
using ScopeIndia.Data;

var builder = WebApplication.CreateBuilder(args);

// ------------------------
// 1. Add Services to Container
// ------------------------

// Add MVC controllers with views
builder.Services.AddControllersWithViews();

// Add EF Core DbContext with SQL Server
builder.Services.AddDbContext<MVCDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register IHttpContextAccessor (needed to access session in _Layout.cshtml)
builder.Services.AddHttpContextAccessor();

// Add session services
builder.Services.AddDistributedMemoryCache(); // Required for session storage
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(7);  // Session setup (default timeout: 7 days)
    options.Cookie.HttpOnly = true;                 // Secure cookie, not accessible via JS
    options.Cookie.IsEssential = true;              // GDPR compliance
});

var app = builder.Build();

// ------------------------
// 2. Configure Middleware
// ------------------------

// Exception handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Enforce HTTPS for production
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Serve static files like CSS, JS, images

app.UseRouting();

// Enable session middleware
app.UseSession();

// Authorization (optional, can add authentication later)
app.UseAuthorization();

// ------------------------
// 3. Define Routes
// ------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hero}/{action=Index}/{id?}");

// ------------------------
// 4. Run the Application
// ------------------------
app.Run();
