using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models.Base;

namespace Lesson1WPF.Models
{

    public class Message : Entity
    {
        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
