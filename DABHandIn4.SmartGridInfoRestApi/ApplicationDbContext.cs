using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABHandIn4.SmartGridInfoRestApi.Entities;
using Microsoft.EntityFrameworkCore;
using Type = DABHandIn4.SmartGridInfoRestApi.Entities.Type;


namespace DABHandIn4.SmartGridInfoRestApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Adresse> Adresse{ get; set; }
        public DbSet<Elkilde> Elkilde { get; set; }
        public DbSet<Har> Har { get; set; }
        public DbSet<SmartEnhed> SmartEnhed { get; set; }
        public DbSet<SmartMeter> SmartMeter { get; set; }
        public DbSet<Type> Type { get; set; }

    }
}
