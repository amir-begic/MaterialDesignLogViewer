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
    public class TelephoneNrValidation : ValidationRule
    {
        private string _patternAreaCodeCH;
        private string _patternAreaCodeDE;
        private string _patternAreaCodeLI;
        private Regex _regex;

        public TelephoneNrValidation()
        {
            _pattern = "^.*";
            _regex = new Regex(_pattern);
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var tel = value as string;

            if (value == null || !_regex.Match(tel).Success)
            {
                return new ValidationResult(false, "The value is not a valid phone number!");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
