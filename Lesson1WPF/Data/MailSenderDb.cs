using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Data
{
    public class MailSenderDb : DbContext
    {
        public DbSet<Server> Servers { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Message> Messages { get; set; }
        public MailSenderDb(DbContextOptions<MailSenderDb> options) : base(options) { }
    }
}
