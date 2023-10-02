using BlazorServerApp.Data;
using BlazorServerApp.Services;
using EmployeeManagement.Models.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("BlazorServerAppContextConnection") ?? throw new InvalidOperationException("Connection string 'BlazorServerAppContextConnection' not found.");

                                    builder.Services.AddDbContext<BlazorServerAppContext>(options =>
                options.UseSqlServer(connectionString));

                                                builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<BlazorServerAppContext>();
            var baseAddress = "https://localhost:7038";
            // Add services to the container.
            builder.Services.AddAuthentication("Identity.Application")
        .AddCookie();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddLogging(context => context.AddDebug());
            builder.Services.AddHttpClient();
            builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
            {
                client.BaseAddress = new Uri(baseAddress);
            });
            builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client =>
            {
                client.BaseAddress = new Uri(baseAddress);
            });
            builder.Services.AddAutoMapper(typeof(EmployeeProfile));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
                        app.UseAuthentication();;

            app.Run();
        }
    }
}