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
    public class UrlValidation :  ValidationRule
    {
        private string _pattern;
        private Regex _regex;

        public UrlValidation()
        {
            _pattern = @"^((https?):\/\/{1})?([a-z0-9]\.)?[a-z0-9]+\.{1}([a-z]+\.{1})?[a-z0-9\/\?\=\&]+";
            _regex = new Regex(_pattern);
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var url = value as string;

            if (value == null || !_regex.Match(url).Success)
            {
                return new ValidationResult(false, "The value is not a valid URL!");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
