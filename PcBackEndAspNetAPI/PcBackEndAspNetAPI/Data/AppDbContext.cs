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

        public PaymentModel Payments { get; set; }
        public CategoryModel Categorys { get; set; }
        public ProductModel Products { get; set; }
        public UserModel Users { get; set; }
        public AddressModel Address { get; set; }
        public OrderItemModel OrdersItems { get; set; }
        public OrderModel Orders { get; set; }
        public CartItemModel CartItems{ get; set; }
        public CartModel Carts { get; set; }
        public BuildComponentModel BuildsComponets { get; set; }
        public CustomBuildModel CustomBuilds { get; set; }
        public FilterModel Filters { get; set; }

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

            // Configure BuildComponentModel
            /* modelBuilder.Entity<BuildComponentModel>(entity =>
            {
                entity.HasKey(bc => bc.Id);
                entity.Property(bc => bc.Type)
                      .IsRequired()
                      .HasMaxLength(50);
            });

            // Configure CustomBuildModel
            modelBuilder.Entity<CustomBuildModel>(entity =>
            {
                entity.HasKey(cb => cb.Id);
                entity.HasOne(cb => cb.User)
                      .WithMany(u => u.CustomBuilds)
                      .HasForeignKey(cb => cb.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(cb => cb.BuildComponents)
                      .WithOne()
                      .HasForeignKey(bc => bc.CustomBuildId)
                      .OnDelete(DeleteBehavior.Cascade);
            }); */
        }
    }
    
}
