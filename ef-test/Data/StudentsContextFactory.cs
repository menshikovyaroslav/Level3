using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_test.Data
{
    public class StudentsContextFactory : IDesignTimeDbContextFactory<StudentsDb>
    {
        public StudentsDb CreateDbContext(string[] args)
        {
            const string connString = @"Data Source=DESKTOP-0NQABKF\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True";

            var optionsBuilder = new DbContextOptionsBuilder<StudentsDb>();
            optionsBuilder.UseSqlServer(connString);

            return new StudentsDb(optionsBuilder.Options);
        }
    }
}
