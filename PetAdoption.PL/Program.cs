
using Microsoft.EntityFrameworkCore;
using PetAdoption.BL.Interfaces;
using PetAdoption.BL.Services;
using PetAdoption.DAL;
using PetAdoption.DAL.Interfaces;
using PetAdoption.DAL.Models;
using PetAdoption.DAL.Repos;


namespace PetAdoption.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
               builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(
                     builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<IPetRepo, PetRepo>();
            builder.Services.AddScoped<IPetService, PetService>();

          //  builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppDbContext>()
             //   .AddDefaultTokenProviders();


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

          //  app.UseAuthentication();
           app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
