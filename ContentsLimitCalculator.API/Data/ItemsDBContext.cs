using Microsoft.EntityFrameworkCore;
using NudeSol.ContentLimitInsurance.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NudeSol.ContentLimitInsurance.WebAPI.Data
{
    public class ItemsDBContext : DbContext
    {
        public ItemsDBContext() : base() { }

        public ItemsDBContext(DbContextOptions<ItemsDBContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
