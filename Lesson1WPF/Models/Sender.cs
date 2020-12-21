using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models.Base;

namespace WpfApp1.Models
{
    [Table(Name = "Senders")]
    public class Sender
    {
        [Column]
        public int Id { get; set; }
        [Column]
        public string Password { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        [Required]
        public string Address { get; set; }
    }
}
