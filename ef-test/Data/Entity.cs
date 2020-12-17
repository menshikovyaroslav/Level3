using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_test.Data
{
    public class Entity
    {
        public int Id { get; set; }
    }

    public class NamedEntity : Entity
    {
        public string Name { get; set; }
    }

    public class Student : NamedEntity
    {
        public string SurName { get; set; }
        public string Family { get; set; }
        public Group Group { get; set; }
    }

    public class Group : NamedEntity
    {
        public string Description { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
