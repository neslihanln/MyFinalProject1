﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{// context: Db tabloları ile proje classlarını bağlamak
   public class NorthwindContext:DbContext
    {
        // veritabnı bağlama
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database= Northwind; Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }  // veritabanı ile benim nesnelerimi neye göre eşeletireceğini gösterir *DbSet*
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer>Customers { get; set; }
    }
}
