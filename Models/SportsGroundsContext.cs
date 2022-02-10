using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsGrounds.Models
{
    public class SportsGroundsContext: IdentityDbContext<User>
    {
        public DbSet<Map>? Maps { get; set; }


        public SportsGroundsContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //  optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SportsGrounds;Trusted_Connection=True;");
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            optionsBuilder
                .UseLazyLoadingProxies()
               .UseSqlite($"Data Source={path}{Path.DirectorySeparatorChar}SportsGrounds.db");

        }
    }
}
