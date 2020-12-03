using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }

    public abstract class EntityName : Entity
    {
        public string Name { get; set; }
    }

    public abstract class Person : EntityName
    {
        public string Address { get; set; }
    }
}
