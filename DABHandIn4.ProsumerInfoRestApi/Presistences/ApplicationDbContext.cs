using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABHandIn4.ProsumerInfoRestApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DABHandIn4.ProsumerInfoRestApi.Presistences
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Forbrug> Forbrug { get; set; }
        public DbSet<PersonAntal> PersonAntal { get; set; }
        public DbSet<Prosumer> Prosumer { get; set; }
    }
}
