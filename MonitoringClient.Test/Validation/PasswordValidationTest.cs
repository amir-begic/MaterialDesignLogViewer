using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonitoringClient.Validation;

namespace MonitoringClient.Test.Validation
{
    [TestClass]
    public class PasswordValidationTest
    {
        [TestMethod]
        public void Password_Is_Not_Eight_Chars_Long()
        {
            var emailValidation = new PasswordValidation();

            var testPw = "T3st!";

            var result = emailValidation.Validate(testPw, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Password_Is_Valid()
        {
            var emailValidation = new PasswordValidation();

            var testPw = "T3st!T3st!";

            var result = emailValidation.Validate(testPw, CultureInfo.CurrentCulture);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Password_Does_Not_Contain_Uppercase()
        {
            var emailValidation = new PasswordValidation();

            var testPw = "t3st!t3st!";

            var result = emailValidation.Validate(testPw, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Password_Does_Not_Contain_Lowercase()
        {
            var emailValidation = new PasswordValidation();

            var testPw = "t3st!t3st!";

            var result = emailValidation.Validate(testPw, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Password_Does_Not_Contain_Special_Char()
        {
            var emailValidation = new PasswordValidation();

            var testPw = "TTT3stt3st";

            var result = emailValidation.Validate(testPw, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Password_Does_Not_Contain_Digit()
        {
            var emailValidation = new PasswordValidation();

            var testPw = "TTT!stt!st";

            var result = emailValidation.Validate(testPw, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
        }
    }
}
