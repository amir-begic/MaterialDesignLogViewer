using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonitoringClient.Validation;

namespace MonitoringClient.Test.Validation
{
    [TestClass]
    public class CustomerValidationTest
    {
        [TestMethod]
        public void Does_CustomerNr_Start_With_CU_Prefix_TRUE()
        {
            var newCustomerNr = "CU32847";
            var validator = new CustomerNrValidation();

            var result = validator.Validate(newCustomerNr, CultureInfo.CurrentCulture);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void CustomerNr_Does_NOT_Start_With_CU_Prefix()
        {
            var newCustomerNr = "3232832";
            var validator = new CustomerNrValidation();

            var result = validator.Validate(newCustomerNr, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void CustomerNr_Too_Short()
        {
            var newCustomerNr = "CU344";
            var validator = new CustomerNrValidation();

            var result = validator.Validate(newCustomerNr, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void CustomerNr_Too_Long()
        {
            var newCustomerNr = "CU34433333";
            var validator = new CustomerNrValidation();

            var result = validator.Validate(newCustomerNr, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void CustomerNr_Does_NOT_Start_With_CU_Prefix_Not_At_Beginning()
        {
            var newCustomerNr = "32CU847";
            var validator = new CustomerNrValidation();

            var result = validator.Validate(newCustomerNr, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
        }
    }
}
