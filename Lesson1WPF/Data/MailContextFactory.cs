using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Data
{
    public class MailContextFactory : IDesignTimeDbContextFactory<MailSenderDb>
    {
        public MailSenderDb CreateDbContext(string[] args)
        {
            const string connString = @"Data Source=DESKTOP-0NQABKF\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True";

            var optionsBuilder = new DbContextOptionsBuilder<MailSenderDb>();
            optionsBuilder.UseSqlServer(connString);

            return new MailSenderDb(optionsBuilder.Options);
        }
    }
}
