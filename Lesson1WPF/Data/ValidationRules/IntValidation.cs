using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Data.ValidationRules
{
    public class IntValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            var result = 0;
            var str = value.ToString();
            Int32.TryParse(str, out result);

            if (result != 0)
            {
                return new ValidationResult(true, "ok");
            }
            else
            {
                return new ValidationResult(false, "Это не число !");
            }
            
        }
    }
}
