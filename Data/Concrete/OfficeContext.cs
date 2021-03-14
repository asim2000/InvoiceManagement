using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete
{
    public class OfficeContext:DbContext
    {
        public DbSet<CashIn> T_CashIn { get; set; }
        public DbSet<CashOut> T_CashOut { get; set; }
        public DbSet<Expence> T_Expence { get; set; }
        public DbSet<Firm> T_Firm { get; set; }
        public DbSet<InvoiceIn> T_InvoiceIn { get; set; }
        public DbSet<InvoiceOut> T_InvoiceOut { get; set; }
        public DbSet<InvoiceInLine> T_InvoiceInLine { get; set; }
        public DbSet<InvoiceOutLine> T_InvoiceOutLine { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"server=.\sqlexpress;database=Db_Office;integrated security=true");
        }
    }
}
