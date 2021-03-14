using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class OfficeContext:DbContext
    {
        public DbSet<User> T_User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"server=.\sqlexpress;database=Db_Office;integrated security=true");
        }
    }
}
