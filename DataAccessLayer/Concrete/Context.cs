﻿using EntityLayer.Concrete;
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
            optionsBuilder.UseSqlServer("server=BULUTS;database=CoreEticaretDb;integrated security=true;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        /**/
        public DbSet<Addres> Addres { get; set; }

        public DbSet<Pay> Pays { get; set; }
        //public DbSet<Users> Users { get; set; }
        public DbSet<Comments> Comments { get; set; }

        //public DbSet<Messages> Messages { get; set; }
        //public DbSet<MessageReplies> MessageReplies { get; set; }
    }
}