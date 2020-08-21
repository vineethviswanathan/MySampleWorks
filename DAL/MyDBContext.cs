using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
    }
}
