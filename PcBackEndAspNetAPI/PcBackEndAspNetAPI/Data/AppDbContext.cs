using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PcBackEndAspNetAPI.Models.CartModels;
using PcBackEndAspNetAPI.Models.CustomBuildModels;
using PcBackEndAspNetAPI.Models.FilterModels;
using PcBackEndAspNetAPI.Models.PaymentModels;
using PcBackEndAspNetAPI.Models.ProductModels;
using PcBackEndAspNetAPI.Models.UsersModels;

namespace PcBackEndAspNetAPI.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public new DbSet<UserModel> Users { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<OrderItemModel> OrderItems { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<CartItemModel> CartItems { get; set; }
        public DbSet<CartModel> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<IdentityRole> roles = new List<IdentityRole>
                {
                    new IdentityRole
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Name = "User",
                        NormalizedName = "USER"
                    },
                };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            modelBuilder.Entity<CategoryModel>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(150);
                entity.Property(p => p.Price)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");
                entity.HasMany(p => p.Categories)
                      .WithMany(c => c.Products);
            });

            modelBuilder.Entity<AddressModel>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.HasOne(a => a.User)
                      .WithMany(u => u.Address)
                      .HasForeignKey(a => a.UserID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(c => c.UserName)
                      .IsRequired()
                      .HasMaxLength(200);
                entity.Property(u => u.PasswordHash)
                      .IsRequired();
            });

            modelBuilder.Entity<OrderModel>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasOne(o => o.User)
                       .WithMany(u => u.Orders)
                       .HasForeignKey(o => o.UserId)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItemModel>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasOne(o => o.Order)
                       .WithMany(u => u.OrderItems)
                       .HasForeignKey(o => o.OrderId)
                       .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(oi => oi.Product)
                      .WithMany()
                      .HasForeignKey(oi => oi.ProductID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CartItemModel>(entity =>
            {
                entity.HasKey(ci => ci.Id);
                entity.HasOne(ci => ci.Cart)
                      .WithMany(c => c.CartItems)
                      .HasForeignKey(ci => ci.CartId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(ci => ci.Product)
                      .WithMany()
                      .HasForeignKey(ci => ci.ProductID)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
    
}
