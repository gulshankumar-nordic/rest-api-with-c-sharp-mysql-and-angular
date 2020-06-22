using BackEndRestAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRestAPI
{
    public class DbApplicationContext: DbContext
    {
        public DbSet<Countries> Countries { get; set; }

        public DbApplicationContext()
        {

        }
        public DbApplicationContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;Database=Countries;Uid=root;Pwd=root");
            }
            
        }
    }
}
