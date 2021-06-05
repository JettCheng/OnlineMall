using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<Customer>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // 初始化用戶與腳色的Seeds
            // 更新用戶與腳色的外鍵關係
            modelBuilder.Entity<Customer>(b => {
                b.HasMany(x => x.UserRoles)
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });

            // 添加角色
            var adminRoleId = "308660dc-ae51-480f-824d-7dca6714c3e2"; // guid 
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId, 
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                }
            );

            // 添加用户
            var adminUserId = "90184155-dee0-40c9-bb1e-b5ed07afc04e";
            Customer adminUser = new Customer
            {
                Id = adminUserId,
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                PhoneNumber = "0912345678",
                PhoneNumberConfirmed = false
            };
            PasswordHasher<Customer> ph = new PasswordHasher<Customer>();
            adminUser.PasswordHash = ph.HashPassword(adminUser, "1qaz@WSX$");
            modelBuilder.Entity<Customer>().HasData(adminUser);

            // 给用户加入管理員權限
            // 通過使用 linking table：IdentityUserRole
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>() 
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}