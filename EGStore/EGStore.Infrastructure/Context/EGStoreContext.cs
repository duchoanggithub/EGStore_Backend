using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EGStore.Infrastructure.Context
{
    public class EGStoreContext : DbContext
    {
        public EGStoreContext()
        {
        }

        public EGStoreContext(DbContextOptions<EGStoreContext> options) : base(options)
        { 
        }

        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Product> Products{ get; set; }
        public virtual DbSet<ProductImg> ProductImgs { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogImg> BlogImgs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Bang Role
            modelBuilder.Entity<Role>(e =>
            {
                e.ToTable("Role");

                e.HasKey(e => e.Id);

                e.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                e.Property(e => e.RoleName).HasColumnType("nvarchar").HasMaxLength(100);

                e.Property(e => e.Describe).HasColumnType("nvarchar").HasMaxLength(4000);

                e.Property(e => e.CreateDay).HasColumnType("datetime");

                e.Property(e => e.UpdateDay).HasColumnType("datetime");

                e.Property(e => e.IsActive).HasColumnType("bit");
            });

            //Bang User
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(e => e.Id);

                e.Property(e => e.Id)
                    .IsRequired()          
                    .ValueGeneratedNever();

                e.Property(e => e.RoleId).ValueGeneratedNever();

                e.Property(e => e.UserName).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);

                e.Property(e => e.Password).IsRequired().HasColumnType("varchar").HasMaxLength(200);

                e.Property(e => e.Email).HasColumnType("nvarchar").HasMaxLength(200);

                e.Property(e => e.AvatarUrl).HasMaxLength(4000).HasColumnType("nvarchar");

                e.Property(e => e.Name).HasMaxLength(50).HasColumnType("nvarchar");

                e.Property(e => e.Phone).HasMaxLength(20).HasColumnType("nvarchar");

                e.Property(e => e.Address).HasMaxLength(255).HasColumnType("nvarchar");

                e.Property(e => e.Sex).HasColumnType("bit");

                e.Property(e => e.CreateDay).HasColumnType("datetime");

                e.Property(e => e.UpdateDay).HasColumnType("datetime");

                e.Property(e => e.IsActive).HasColumnType("bit");

                e.HasOne(p => p.Role)
                    .WithMany(c => c.Users)
                    .HasForeignKey(e => e.RoleId);
            });

            //Bang Delivery
            modelBuilder.Entity<Delivery>(e =>
            {
                e.ToTable("Delivery");
                e.HasKey(e => e.Id);

                e.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                e.Property(e => e.DeliveryName).HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.DeliPhone).HasColumnType("nvarchar").HasMaxLength(20);

                e.Property(e => e.CreateDay).HasColumnType("datetime");

                e.Property(e => e.UpdateDay).HasColumnType("datetime");

                e.Property(e => e.IsActive).HasColumnType("bit");

            });

            //Bang Supplier
            modelBuilder.Entity<Supplier>(e =>
            {
                e.ToTable("Supplier");
                e.HasKey(e => e.Id);

                e.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                e.Property(e => e.SupName).HasColumnType("nvarchar").HasMaxLength(200);

                e.Property(e => e.ContactPerson).HasColumnType("nvarchar").HasMaxLength(200);

                e.Property(e => e.PhoneContact).HasColumnType("nvarchar").HasMaxLength(20);

                e.Property(e => e.Address).HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.Email).HasColumnType("nvarchar").HasMaxLength(4000);

                e.Property(e => e.CreateDay).HasColumnType("datetime");

                e.Property(e => e.UpdateDay).HasColumnType("datetime");

                e.Property(e => e.IsActive).HasColumnType("bit");

            });

            //Bang Category
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Category");
                e.HasKey(e => e.Id);

                e.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                e.Property(e => e.CateProdName).IsRequired().HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.Describe).HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.CreateDay).HasColumnType("datetime");

                e.Property(e => e.UpdateDay).HasColumnType("datetime");

                e.Property(e => e.IsActive).HasColumnType("bit");
            });

            //Bang Product
            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Product");
                e.HasKey(e => e.Id);

                e.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                e.Property(e => e.SupId).ValueGeneratedNever();

                e.Property(e => e.CategoryId).ValueGeneratedNever();

                e.Property(e => e.ProdCode).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);

                e.Property(e => e.ProdName).IsRequired().HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.Price).IsRequired().HasColumnType("float");

                e.Property(e => e.Discount).IsRequired().HasColumnType("float");

                e.Property(e => e.Inventory).IsRequired().HasColumnType("float");

                e.Property(e => e.ProdImg).HasColumnType("nvarchar").HasMaxLength(4000);

                e.Property(e => e.Color).HasColumnType("nvarchar").HasMaxLength(50);

                e.Property(e => e.Origin).HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.Sex).HasColumnType("bit");

                e.Property(e => e.Designs).HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.FrameMaterial).HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.Suitable).HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.Describe).HasColumnType("nvarchar").HasMaxLength(4000);

                e.Property(e => e.UV).HasColumnType("bit");

                e.Property(e => e.CreateDay).HasColumnType("datetime");

                e.Property(e => e.UpdateDay).HasColumnType("datetime");

                e.Property(e => e.Status).HasColumnType("bit");

                e.HasOne(p => p.Supplier)
                    .WithMany(c => c.Products)
                    .HasForeignKey(e => e.SupId);

                e.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(e => e.CategoryId);
            });

            /*Bang ProductImg
            modelBuilder.Entity<ProductImg>(e =>
            {
                e.ToTable("ProductImg");
                e.HasKey(e => e.Id);

                e.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                e.Property(e => e.ProdId).ValueGeneratedNever();

                e.Property(e => e.Img).HasColumnType("nvarchar").HasMaxLength(4000);

                e.HasOne(p => p.Product)
                    .WithMany(c => c.ProductImgs)
                    .HasForeignKey(e => e.ProdId);
            });*/

            //Bang Blog
            modelBuilder.Entity<Blog>(e =>
            {
                e.ToTable("Blog");
                e.HasKey(e => e.Id);

                e.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                e.Property(e => e.Title).HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.Author).HasColumnType("nvarchar").HasMaxLength(50);

                e.Property(e => e.Content).HasColumnType("nvarchar").HasMaxLength(4000);

                e.Property(e => e.BlogImg).HasColumnType("nvarchar").HasMaxLength(4000);

                e.Property(e => e.UpDay).HasColumnType("datetime");

                e.Property(e => e.UpdateDay).HasColumnType("datetime");

                e.Property(e => e.IsActive).HasColumnType("bit");

            });

            /*Bang BlogImg
            modelBuilder.Entity<BlogImg>(e =>
            {
                e.ToTable("BlogImg");
                e.HasKey(e => e.Id);

                e.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                e.Property(e => e.BlogId).ValueGeneratedNever();

                e.Property(e => e.Img).HasColumnType("nvarchar").HasMaxLength(4000);

                e.HasOne(p => p.Blog)
                    .WithMany(c => c.BlogImgs)
                    .HasForeignKey(e => e.BlogId);
            });*/

            //Bang Order
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(e => e.Id);

                e.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                e.Property(e => e.DeliveryId).ValueGeneratedNever();

                e.Property(e => e.UserId).ValueGeneratedNever();

                e.Property(e => e.CusName).HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.CusPhone).HasColumnType("nvarchar").HasMaxLength(20);

                e.Property(e => e.Email).HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.Address).HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.NotePay).HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.PaymentMenthods).HasColumnType("nvarchar").HasMaxLength(250);

                e.Property(e => e.OrderDate).HasColumnType("datetime");

                e.Property(e => e.DeliveryDate).HasColumnType("datetime");

                e.Property(e => e.CreateDay).HasColumnType("datetime");

                e.Property(e => e.UpdateDay).HasColumnType("datetime");

                e.Property(e => e.Status).HasColumnType("bit");

                e.HasOne(p => p.Delivery)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(e => e.DeliveryId);

                e.HasOne(p => p.User)
                   .WithMany(c => c.Orders)
                   .HasForeignKey(e => e.UserId);
            });

            //Bang OrderProduct
            modelBuilder.Entity<OrderProduct>(e =>
            {
                e.ToTable("OrderProduct");
                e.HasKey(e => e.Id);

                e.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                e.Property(e => e.OrderId).ValueGeneratedNever();

                e.Property(e => e.ProdId).ValueGeneratedNever();

                e.Property(e => e.ProdName).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);

                e.Property(e => e.Amount).HasColumnType("float");

                e.Property(e => e.UnitPrice).HasColumnType("float");

                e.Property(e => e.Sum).HasColumnType("float");

                e.Property(e => e.CreateDay).HasColumnType("datetime");

                e.Property(e => e.UpdateDay).HasColumnType("datetime");

                e.Property(e => e.Status).HasColumnType("bit");

                e.HasOne(p => p.Order)
                    .WithMany(c => c.OrderProducts)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.NoAction);

                e.HasOne(p => p.Product)
                    .WithMany(c => c.OrderProducts)
                    .HasForeignKey(e => e.ProdId);
            });
        }
    }
}