using System.Globalization;
using System.Management.Instrumentation;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MonitoringClient.Validation
{
    public class CustomerNrValidation : ValidationRule
    {
        private string _pattern;
        private Regex _regex;

        public CustomerNrValidation()
        {
            _pattern = "^CU.*";
            _regex = new Regex(_pattern);
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var customernr = value as string;

            if (value == null || !_regex.Match(customernr).Success)
            {
                return new ValidationResult(false, "The value is not a valid Customer Number!");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}