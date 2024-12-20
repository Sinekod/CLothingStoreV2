using ClothingStore.Core.Contracts;
using ClothingStore.Core.Services;
using ClothingStore.Infrastructure.Data;
using ClothingStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreAgain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ClothingStoreDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<ClothingStoreDbContext>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IServiceProducts, ProductService>();
            builder.Services.AddScoped<IAdminServices, AdminService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IRoleManagerService, RoleService>();
            builder.Services.AddScoped<IOrderService, OrderServices>();
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options => 
            {
                options.Cookie.Name = "SessionCookie";
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                // Global exception handler for unhandled exceptions (500 errors)
                app.UseExceptionHandler("/Error/500");

                // Handle specific status codes like 404, 403, etc.
                app.UseStatusCodePagesWithRedirects("/Error/{0}");

                // Enable HSTS for production
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.Use(async (context, next) =>
            {
                try
                {
                    await next(); // Process request
                }
                catch (Exception)
                {
                    context.Response.Redirect("/Error/500");
                }

                if (context.Response.StatusCode == 404)
                {
                    context.Response.Redirect("/Error/404");
                }
            });

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
             
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "Admin/{controller=Admin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                name: "admin",
                  
                    pattern: "Admin/{controller=Roles}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            app.Run();
        }
    }
}
