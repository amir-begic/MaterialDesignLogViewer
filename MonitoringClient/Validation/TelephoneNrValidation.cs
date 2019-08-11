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
        private readonly string _patternLocal = "^([0-9()]{3})\\/?([0-9]{5})-?([0-9]{2})?$";
        private readonly string _patternAreaCodeInternationalCh = "^(\\+41|0041)(?:\\(0\\))?([0-9()]{2})([0-9]{5})-?([0-9]{2})?$";
        private readonly string _patternAreaCodeInternationalDe = "^(\\+49|0049)(?:\\(0\\))?([0-9()]{2})([0-9]{5})-?([0-9]{2})?$";
        private readonly string _patternAreaCodeInternationalLi = "^(\\+423|00423)(?:\\(0\\))?([0-9()]{2})([0-9]{5})-?([0-9]{2})?$";

        private readonly Regex _regexLocal;
        private readonly Regex _regexAreaCodeCHInternational;
        private readonly Regex _regexAreaCodeDEInternational;
        private readonly Regex _regexAreaCodeLInternationalI;


        public TelephoneNrValidation()
        {
            //_patternAreaCodeCH = "";
            _regexLocal = new Regex(_patternLocal);
            _regexAreaCodeCHInternational = new Regex(_patternAreaCodeInternationalCh);
            _regexAreaCodeDEInternational = new Regex(_patternAreaCodeInternationalDe);
            _regexAreaCodeLInternationalI = new Regex(_patternAreaCodeInternationalLi);

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var tel = value as string;
            if (tel == null)
            {
                return new ValidationResult(false, "value was null.");
            }

            tel = tel.Replace(" ", string.Empty);
            

            if (tel == null || !_regexAreaCodeCHInternational.Match(tel).Success
                            && !_regexAreaCodeDEInternational.Match(tel).Success
                            && !_regexAreaCodeLInternationalI.Match(tel).Success
                            && !_regexLocal.Match(tel).Success)
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
