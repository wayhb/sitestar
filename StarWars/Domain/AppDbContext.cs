using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Entities;

namespace StarWars.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<CharacterItem> CharacterItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // создание роли
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "d6b6e5d9-c8ea-47db-98c9-4e30bc12e50b",
                Name = "admin",
                NormalizedName = "admin"
            });
            //создание пользователя
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "89121f50-8413-4eb1-a900-714d7bf2f269",
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "my@email.com",
                NormalizedEmail = "my@email.com",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty

            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "d6b6e5d9-c8ea-47db-98c9-4e30bc12e50b",
                UserId = "89121f50-8413-4eb1-a900-714d7bf2f269"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("ea37be41-b657-4b39-95f2-025cfef45246"),
                CodeWord  = "PageIndex",
                Name = "Главная"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("2cd38e76-56e3-4f68-96e5-e14202439b1d"),
                CodeWord = "PageCharacters",
                Name = "Персонажи"
            });
        }

    }
}
