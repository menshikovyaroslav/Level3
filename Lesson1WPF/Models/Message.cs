using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1WPF.Models
{
    [Table(Name = "Recipients")]
    public class Message
    {
        [Column]
        public int Id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string Value { get; set; }
    }
}
