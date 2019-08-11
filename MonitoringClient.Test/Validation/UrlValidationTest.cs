using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonitoringClient.Validation;

namespace MonitoringClient.Test.Validation
{
    [TestClass]
    public class UrlValidationTest
    {
        [TestMethod]
        public void URL_Without_Subdomain_Without_Protocol()
        {
            var testUrl = "google.com";
            var urlValidator = new UrlValidation();

            var result = urlValidator.Validate(testUrl, CultureInfo.CurrentCulture);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void URL_With_Protocool_And_Subdomain()
        {
            var testUrl = "http://www.google.com";
            var urlValidator = new UrlValidation();

            var result = urlValidator.Validate(testUrl, CultureInfo.CurrentCulture);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void URL_With_Subdomain()
        {
            var testUrl = "google.com";
            var urlValidator = new UrlValidation();

            var result = urlValidator.Validate(testUrl, CultureInfo.CurrentCulture);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void URL_With_Path()
        {
            var testUrl = "https://google.com/validation";
            var urlValidator = new UrlValidation();

            var result = urlValidator.Validate(testUrl, CultureInfo.CurrentCulture);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void URL_With_Path_and_Parameters()
        {
            var testUrl = "https://policies.google.com/technologies/voice?hl=de&gl=ch";
            var urlValidator = new UrlValidation();

            var result = urlValidator.Validate(testUrl, CultureInfo.CurrentCulture);

            Assert.IsTrue(result.IsValid);
        }
    }
}
