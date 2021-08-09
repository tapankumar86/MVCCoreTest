using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class DatabaseContext : IdentityDbContext<User, Role, int>
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=CSMBHUL366\\SQLEXPRESS; initial catalog=MyProject;persist security info=True;user id=sa;password=csmpl@123;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
