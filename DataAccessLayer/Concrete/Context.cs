using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=BULUTS;database=CoreETicaretDB;integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(c => new { c.CategoryId, c.ProductId });

            ////modelBuilder.Entity<Category>()
            //.HasKey(c => new { c.Id, c.ChildrenCategory });
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        /**/
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Pay> Pays { get; set; }
        //public DbSet<Users> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }

        //public DbSet<Messages> Messages { get; set; }
        //public DbSet<MessageReplies> MessageReplies { get; set; }

        public DbSet<Writer> Writers { get; set; }
        //public DbSet<Listing> Listings { get; set; }
        //public DbSet<SubCategory1> SubCategories1 { get; set; }
        //public DbSet<SubCategory2> SubCategories2 { get; set; }
    }
}
