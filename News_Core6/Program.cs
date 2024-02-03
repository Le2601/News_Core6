using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using News_Core6.DI.New;
using News_Core6.DI.Post;
using News_Core6.DI.User.Home;
using News_Core6.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. //tu load trang khi save .cshtml
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.WebHost.ConfigureAppConfiguration((hostingContext, config) =>
{
    // ... cấu hình khác

    if (hostingContext.HostingEnvironment.IsDevelopment())
    {
        builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
        builder.Services.AddScoped<INewRepository, NewRepository>();
        builder.Services.AddScoped<IPostRepository, PostRepository>();
        builder.Services.AddScoped<IHomeRepository, HomeRepository>();

        // Trong phương thức ConfigureServices của Startup.cs
        //builder.Services.AddDistributedRedisCache(options =>
        //{
        //    options.Configuration = "localhost"; // Thay đổi thành địa chỉ Redis của bạn
        //    options.InstanceName = "SampleInstance";
        //});
    }
});



//connect db
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=LAPTOP-LH4CD5VL;Database=New_Core6;Trusted_Connection=True;Connect Timeout=60;MultipleActiveResultSets=True");
});
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("NewConnection")));

//sesion
builder.Services.AddSession(options =>
{

    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});






builder.Services.AddResponseCaching();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(p =>
              {
                  p.Cookie.Name = "UserLoginCookie";
                  //xet tg ton tai cua phien dang nhap
                  p.ExpireTimeSpan = TimeSpan.FromHours(1);
                  p.LoginPath = "/dang-nhap-admin.html";
                  //p.LogoutPath = "/dang-xuat/html";
                  //p.AccessDeniedPath = "/not-found.html";
              });






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

app.UseSession();  // Kích hoạt Middleware Session

app.UseAuthentication();

app.UseAuthorization();

//app.MapGet("/le",() => "toi la le");


app.UseResponseCaching();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});






app.Run();
