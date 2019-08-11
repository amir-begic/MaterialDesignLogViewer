using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MonitoringClient.Validation
{
    public class PasswordValidation : ValidationRule
    {
        private string _pattern;
        private Regex _regex;

        public PasswordValidation()
        {
            _pattern = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
            _regex = new Regex(_pattern);
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var password = value as string;

            if (value == null || !_regex.Match(password).Success)
            {
                return new ValidationResult(false, "The value is not a valid password!");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
