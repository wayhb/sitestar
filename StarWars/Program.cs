using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StarWars.Domain;
using StarWars.Domain.Repositories.Abstract;
using StarWars.Domain.Repositories.EntityFramework;
using StarWars.Service;
using System.Data;

namespace StarWars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

			// ���������� ������ �� appsetting.json
			builder.Configuration.Bind("Project", new Config());

            // ���������� ������ ���������� ���������� � �������� ��������
            builder.Services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            builder.Services.AddTransient<ICharactersItemsRepository, EFCharacterItemsRepository>();
            builder.Services.AddTransient<DataManager>();

            // ����������� � ��
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=db.db"));

    //        builder.Services.AddDefaultIdentity<ApplicationUser>()
    //.AddEntityFrameworkStores<ApplicationContext>();
            //OptionsBuilder.UseSqlite("Data Source=db.db; Password='am';");
            //����������� identity �������
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;                
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();// ���-�� ��� ��
            // ����������� authentification cookies
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth"; // change
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;

            });
            // ����������� �������� ����������� ��� AdminArea
            builder.Services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            // ���������� ��������� ����������� � ������������� mvc 
            builder.Services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
				// ����������� ������������� � asp.net core 3.0
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

			var app = builder.Build();
            //	� �������� ���������� ��� ����� ������ ����� ������ ������
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // ���������� ��������� ��������� ������ � ����������( js, css � ��)
            app.UseStaticFiles();

            // ���������� ������� �������������
            app.UseRouting();

			// ���������� �������������� � �����������
			app.UseCookiePolicy();
			app.UseAuthentication();
			app.UseAuthorization();

			// ������������ ������ ��� ��������(���������)
			app.UseEndpoints(endpoints =>
			{
                endpoints.MapControllerRoute("admin", "{area=exist}/{controller=Home}/" +
                    "{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/" +
					"{action=Index}/{id?}");
			});
            app.MapRazorPages();

            app.Run();  
			

		}
    }
}
