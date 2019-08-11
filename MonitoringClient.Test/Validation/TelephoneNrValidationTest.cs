using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonitoringClient.Validation;

namespace MonitoringClient.Test.Validation
{
    [TestClass]
    public class TelephoneNrValidationTest
    {
        [TestMethod]
        public void Is_Swiss_International_Number()
        {
            var phoneNrValidation = new TelephoneNrValidation();

            var phoneNr1 = "+41 75 409 00 00";
            var phoneNr2 = "0041 75 409 00 00";
            var phoneNr3 = "0041 (0)75 409 00 00";

            var result1 = phoneNrValidation.Validate(phoneNr1, CultureInfo.CurrentCulture);
            var result2 = phoneNrValidation.Validate(phoneNr2, CultureInfo.CurrentCulture);
            var result3 = phoneNrValidation.Validate(phoneNr3, CultureInfo.CurrentCulture);

            Assert.IsTrue(result1.IsValid && result2.IsValid && result3.IsValid);
        }

        [TestMethod]
        public void Is_German_International_Number()
        {
            var phoneNrValidation = new TelephoneNrValidation();

            var phoneNr1 = "+49 75 409 00 00";
            var phoneNr2 = "0049 (0)69 365 9198";
            var phoneNr3 = "+49 (0)69 365 9198";

            var result1 = phoneNrValidation.Validate(phoneNr1, CultureInfo.CurrentCulture);
            var result2 = phoneNrValidation.Validate(phoneNr2, CultureInfo.CurrentCulture);
            var result3 = phoneNrValidation.Validate(phoneNr3, CultureInfo.CurrentCulture);

            Assert.IsTrue(result1.IsValid && result2.IsValid && result3.IsValid);
        }

        [TestMethod]
        public void Is_Lichtenstein_International_Number()
        {
            var phoneNrValidation = new TelephoneNrValidation();

            var phoneNr1 = "+423 75 409 00 00";
            var phoneNr2 = "00423 75 409 00 00";
            var phoneNr3 = "00423 (0)75 409 00 00";

            var result1 = phoneNrValidation.Validate(phoneNr1, CultureInfo.CurrentCulture);
            var result2 = phoneNrValidation.Validate(phoneNr2, CultureInfo.CurrentCulture);

            Assert.IsTrue(result1.IsValid && result2.IsValid);
        }

        [TestMethod]
        public void Is_Local_All_Countries()
        {
            var phoneNrValidation = new TelephoneNrValidation();

            var phoneNr1 = "069 365 9198";
            var phoneNr2 = "075 409 00-00";
            var phoneNr3 = "023 / 214 54";

            var result1 = phoneNrValidation.Validate(phoneNr1, CultureInfo.CurrentCulture);
            var result2 = phoneNrValidation.Validate(phoneNr2, CultureInfo.CurrentCulture);
            var result3 = phoneNrValidation.Validate(phoneNr3, CultureInfo.CurrentCulture);

            Assert.IsTrue(result1.IsValid && result2.IsValid && result3.IsValid);
        }
    }
}
