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
    public class EmailValidation : ValidationRule
    {
        private string _pattern;
        private Regex _regex;

        public EmailValidation()
        {
            _pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            _regex = new Regex(_pattern);
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var email = value as string;

            if (value == null || !_regex.Match(email).Success)
            {
                return new ValidationResult(false, "The value is not a valid Email!");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}

