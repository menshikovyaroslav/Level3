using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models.Base;

namespace WpfApp1.Models
{
    [Table(Name = "Servers")]
    public class Server
    {
        [Column]
        public int Id { get; set; }
        [Column]
        public bool IsSSL { get; set; }
        [Column]
        public string Address { get; set; }
        [Column]
        public int Port { get; set; }

        public string FullAddress { get { return $"{Address}:{Port}"; } }
    }
}
