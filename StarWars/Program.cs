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

			// подключаем конфиг из appsetting.json
			builder.Configuration.Bind("Project", new Config());

            // подключаем нужный функционал приложения в качестве сервисов
            builder.Services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            builder.Services.AddTransient<ICharactersItemsRepository, EFCharacterItemsRepository>();
            builder.Services.AddTransient<DataManager>();

            // подключение к бд
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=db.db"));

    //        builder.Services.AddDefaultIdentity<ApplicationUser>()
    //.AddEntityFrameworkStores<ApplicationContext>();
            //OptionsBuilder.UseSqlite("Data Source=db.db; Password='am';");
            //настраиваем identity систему
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;                
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();// что-то про дб
            // настраиваем authentification cookies
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth"; // change
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;

            });
            // настраиваем политику авторизации для AdminArea
            builder.Services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            // добавление поддержки конроллеров и представлений mvc 
            builder.Services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
				// выставление совместимости с asp.net core 3.0
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

			var app = builder.Build();
            //	в процессе разработки нам важно видеть какие именно ошибки
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // подключаем поддержку статичных файлов в приложении( js, css и тд)
            app.UseStaticFiles();

            // подключаем систему маршрутизации
            app.UseRouting();

			// подключаем аутентификацию и авторизацию
			app.UseCookiePolicy();
			app.UseAuthentication();
			app.UseAuthorization();

			// регистрируем нужные нам маршруты(эндпоинты)
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
