using ClinicalManagementSystem.Repository;
using ClinicalManagementSystem.Service;

namespace ClinicalManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ? Add services to the container
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(); // ? Enable session
            builder.Services.AddHttpContextAccessor(); // ? Needed for session/context

            // ? Register repositories and services
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IRoleService, RoleService>();

            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IAdminService, AdminService>();

            // ? Build app
            var app = builder.Build();

            // ? Middleware pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession(); // ? Use session
            app.UseAuthorization();

            // ? Default route to Login controller
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
