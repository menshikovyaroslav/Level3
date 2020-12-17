using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
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
        public virtual string Name { get; set; }
    }

    public abstract class Person : EntityName
    {
        public virtual string Address { get; set; }
    }
}
