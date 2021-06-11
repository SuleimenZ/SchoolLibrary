using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchoolLibrary.Areas.Identity.Data;
using SchoolLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SchoolLibrary.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<IdentityUserClaim<string>> IdentityUserClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { id = 1, title = "Effective C#, 2nd Edition", price = 5  },
                new Book { id = 2, title = "C# 3.0 Cookbook, 3rd Edition", price = 4.2 },
                new Book { id = 3, title = "Learning C# 3.0", price = 24.5 },
                new Book { id = 4, title = "Programming C# 3.0, Fifth Edition", price = 8.5 },
                new Book { id = 5, title = "C# 3.0 Design Patterns", price = 3.7 },
                new Book { id = 6, title = "Build Your Own ASP.NET 4 Web Site Using C# & VB, 4th Edition", price = 29 },
                new Book { id = 7, title = "C# 9.0 Pocket Reference", price = 20 },
                new Book { id = 8, title = "C# Deconstructed", price = 56.7 },
                new Book { id = 9, title = "C# Database Basics", price = 17 },
                new Book { id = 10, title = "C# 5.0 Pocket Reference", price = 11.8 }
                );
        }
    }
}