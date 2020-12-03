using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models.Base;

namespace Lesson1WPF.Models
{
    public class Recipient : Person, IDataErrorInfo
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

        public override string Name { get => base.Name;
            set
            {
           //     if (value is null) throw new ArgumentException("Пустое имя", nameof(value));
          //      if (value == "") throw new ArgumentException("Пустое имя", nameof(value));
          //      if (value.Length < 3) throw new ArgumentException("Слишком короткое имя", nameof(value));
           //     if (value == "Usama") throw new ArgumentException("Нельзя выбрать такое имя !", nameof(value));

                base.Name = value;
            }
        }

        public string Error => throw new NotImplementedException();
    }
}
