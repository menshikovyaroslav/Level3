using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models.Base;

namespace WpfApp1.Models
{
    [Table(Name = "Messages")]
    public class Message
    {
        [Column]
        public int Id { get; set; }
        [Column]
        public string Subject { get; set; }
        [Column]
        public string Body { get; set; }
        [Column]
        public int RecipientId { get; set; }
        [Column]
        public int ServerId { get; set; }
        [Column]
        public bool Sended { get; set; }
        [Column]
        public string Time { get; set; }

        public DateTime DateTime
        {
            get
            {
                var result = DateTime.MaxValue;
                var splitted = Time?.Split('-');
                if (splitted?.Length == 3)
                {
                    try
                    {
                        result = new DateTime(Int32.Parse(splitted[0]), Int32.Parse(splitted[1]), Int32.Parse(splitted[2]));
                    }
                    catch (Exception)
                    {
                    }
                }
                return result;
            }
        }

    }
}
