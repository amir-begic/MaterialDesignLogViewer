using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonitoringClient.Validation;

namespace MonitoringClient.Test.Validation
{
    [TestClass]
    public class EmailValidationTest
    {
        [TestMethod]
        public void Email_Valid()
        {
            var emailValidation = new EmailValidation();

            var testString = "test@test.de";

            var result = emailValidation.Validate(testString, CultureInfo.CurrentCulture);
            
            Assert.IsTrue(result.IsValid);
        }
        
        [TestMethod]
        public void Email_Including_Tags()
        {
            var emailValidation = new EmailValidation();

            var testString = "user.name+tag+sorting@example.com";

            var result = emailValidation.Validate(testString, CultureInfo.CurrentCulture);

            Assert.IsTrue(result.IsValid);  
        }

        [TestMethod]
        public void Email_Invalid_Multiple_AT_Chars()
        {
            var emailValidation = new EmailValidation();

            var testString = "A@b@c@example.com";

            var result = emailValidation.Validate(testString, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Email_Quotes_And_Backslash_Inside_Adress()
        {
            var emailValidation = new EmailValidation();

            var testString = @"this is""not\allowed @example.com";

            var result = emailValidation.Validate(testString, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Email_Address_Longer_Than_Valid()
        {
            
            var emailValidation = new EmailValidation();

            var testString = "1234567890123456789012345678901234567890123456789012345678901234+x@example.com";

            var result = emailValidation.Validate(testString, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid, "The Email cant be longer than 64 octets as per RFC. The Regex fails this test.");
        }

        [TestMethod]
        public void Email_Single_Whitespace_Between_Quotes()
        {
            var emailValidation = new EmailValidation();

            var testString = "\" \"@example.org";

            var result = emailValidation.Validate(testString, CultureInfo.CurrentCulture);

            Assert.IsTrue(result.IsValid, "The Email Address may have whitespace charachters as long as it's sourrounded by quotes.");
        }


         [TestMethod]
        public void Email_Double_Whitespace()
        {
            var emailValidation = new EmailValidation();

            var testString = "tes\"  \"tt@test.de";

            var result = emailValidation.Validate(testString, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Email_With_Hyphens()
        {
            var emailValidation = new EmailValidation();

            var testString = "example-indeed@strange-example.com";

            var result = emailValidation.Validate(testString, CultureInfo.CurrentCulture);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Email_Without_TLD()
        {
            var emailValidation = new EmailValidation();

            var testString = "indeed@strange-example";

            var result = emailValidation.Validate(testString, CultureInfo.CurrentCulture);

            Assert.IsTrue(result.IsValid, "local domain name with no TLD should be possible");
        }

        [TestMethod]
        public void Email_With_Quoted_Doubledot()
        {
            var emailValidation = new EmailValidation();

            var testString = "\"john..doe\"@example.org";

            var result = emailValidation.Validate(testString, CultureInfo.CurrentCulture);

            Assert.IsTrue(result.IsValid);
        }
    }
}
