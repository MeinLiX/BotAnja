using System;
using System.IO;
using BotAnja.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace BotAnja.DB
{
    class Context : DbContext
    {
        public DbSet<User> Users { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@$"Filename={Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\DB\BotAnja.db"}");
        }
    }
}