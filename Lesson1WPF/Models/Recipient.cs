using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace WpfApp1.Models
{
    [Table(Name = "Recipients")]
    public class Recipient : IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    if (Name == "Ivan") return "Нельзя выбрать такое имя !";
                    if (Name.Length < 3 || Name.Length > 7) return "Неверная длина";
                }

                return "";
            }
        }
        [Column]
        public int Id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        [Required, MaxLength(120), MinLength(10)]
        public string Address { get; set; }

        public string Error => throw new NotImplementedException();
    }
}
