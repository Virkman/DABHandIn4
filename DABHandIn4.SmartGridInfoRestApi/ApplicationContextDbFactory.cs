using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DABHandIn4.SmartGridInfoRestApi
{
    public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext db;

        public ApplicationContextDbFactory()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //optionsBuilder.UseSqlServer<ApplicationDbContext>(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DAB4DB;Integrated Security=True");
            optionsBuilder.UseSqlServer<ApplicationDbContext>(@"Data Source=st-i4dab.uni.au.dk.;Initial Catalog=E18I4DABH4Gr15;User ID=E18I4DABH4Gr15;Password=E18I4DABH4Gr15");
            db = new ApplicationDbContext(optionsBuilder.Options);
        }
        ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
        {
            return db;
        }
    }
}
