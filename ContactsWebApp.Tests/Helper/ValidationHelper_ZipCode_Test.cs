using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ContactsWebApp.Helper.ValidationHelper;

namespace ContactsWebApp.Tests.Helper
{
    [TestClass]
    public class ValidationHelper_ZipCode_Test
    {
        #region Correct Pattern
        /// <summary>
        /// Testing the validation for a correct pattern
        /// </summary>
        [TestMethod]
        public void CorrectPatternValidationFirstTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationZipCode getReturnValidationZipCode = null;

            string countryName = "Brazil";
            string zipcode = "00000-000";

            getReturnValidationZipCode = new GetReturnValidationZipCode(validationHelper.ValidateZipCode);
            Assert.IsTrue(getReturnValidationZipCode(countryName, zipcode));
        }

        /// <summary>
        /// Testing the validation for a correct pattern
        /// </summary>
        [TestMethod]
        public void CorrectPatternValidationSecondTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationZipCode getReturnValidationZipCode = null;

            string countryName = "United States";
            string zipcode = "99577-0727";

            getReturnValidationZipCode = new GetReturnValidationZipCode(validationHelper.ValidateZipCode);
            Assert.IsTrue(getReturnValidationZipCode(countryName, zipcode));
        }

        /// <summary>
        /// Testing the validation for a correct pattern
        /// </summary>
        [TestMethod]
        public void CorrectPatternValidationThirdTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationZipCode getReturnValidationZipCode = null;

            string countryName = "United States";
            string zipcode = "55416";

            getReturnValidationZipCode = new GetReturnValidationZipCode(validationHelper.ValidateZipCode);
            Assert.IsTrue(getReturnValidationZipCode(countryName, zipcode));
        }
        #endregion

        #region Wrong Pattern
        /// <summary>
        /// Testing the validation for a wrong pattern
        /// </summary>
        [TestMethod]
        public void WrongPatternValidationFirstTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationZipCode getReturnValidationZipCode = null;

            string countryName = "Brazil";
            string zipcode = "00000";
            
            getReturnValidationZipCode = new GetReturnValidationZipCode(validationHelper.ValidateZipCode);
            Assert.IsFalse(getReturnValidationZipCode(countryName, zipcode));
        }

        /// <summary>
        /// Testing the validation for a wrong pattern
        /// </summary>
        [TestMethod]
        public void WrongPatternValidationSecondTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationZipCode getReturnValidationZipCode = null;

            string countryName = "Brazil";
            string zipcode = "00000-0000";

            getReturnValidationZipCode = new GetReturnValidationZipCode(validationHelper.ValidateZipCode);
            Assert.IsFalse(getReturnValidationZipCode(countryName, zipcode));
        }
        #endregion

        #region Null Information
        /// <summary>
        /// Testing the validation for a null information for country name
        /// </summary>
        [TestMethod]
        public void NullCountryValidationSecondTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationZipCode getReturnValidationZipCode = null;

            string countryName = null;
            string zipcode = "00000";

            getReturnValidationZipCode = new GetReturnValidationZipCode(validationHelper.ValidateZipCode);
            Assert.IsFalse(getReturnValidationZipCode(countryName, zipcode));
        }

        /// <summary>
        /// Testing the validation for a null information for zip code
        /// </summary>
        [TestMethod]
        public void NullZipCodeValidationSecondTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationZipCode getReturnValidationZipCode = null;

            string countryName = "Brazil";
            string zipcode = null;

            getReturnValidationZipCode = new GetReturnValidationZipCode(validationHelper.ValidateZipCode);
            Assert.IsFalse(getReturnValidationZipCode(countryName, zipcode));
        }

        /// <summary>
        /// Testing the validation for a null information for both country and zip code
        /// </summary>
        [TestMethod]
        public void NullCountryZipcodeValidationSecondTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationZipCode getReturnValidationZipCode = null;

            string countryName = null;
            string zipcode = null;

            getReturnValidationZipCode = new GetReturnValidationZipCode(validationHelper.ValidateZipCode);
            Assert.IsFalse(getReturnValidationZipCode(countryName, zipcode));
        }
        #endregion

        #region Empty Information
        /// <summary>
        /// Testing the validation for an empty information for country name
        /// </summary>
        [TestMethod]
        public void EmptyCountryValidationSecondTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationZipCode getReturnValidationZipCode = null;

            string countryName = "Brazil";
            string zipcode = "";

            getReturnValidationZipCode = new GetReturnValidationZipCode(validationHelper.ValidateZipCode);
            Assert.IsFalse(getReturnValidationZipCode(countryName, zipcode));
        }

        /// <summary>
        /// Testing the validation for an empty information for zip code
        /// </summary>
        [TestMethod]
        public void EmptyZipCodeValidationSecondTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationZipCode getReturnValidationZipCode = null;

            string countryName = "Brazil";
            string zipcode = "";

            getReturnValidationZipCode = new GetReturnValidationZipCode(validationHelper.ValidateZipCode);
            Assert.IsFalse(getReturnValidationZipCode(countryName, zipcode));
        }

        /// <summary>
        /// Testing the validation for an empty information for both country and zip code
        /// </summary>
        [TestMethod]
        public void EmptyCountryZipcodeValidationSecondTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationZipCode getReturnValidationZipCode = null;

            string countryName = "Brazil";
            string zipcode = "";

            getReturnValidationZipCode = new GetReturnValidationZipCode(validationHelper.ValidateZipCode);
            Assert.IsFalse(getReturnValidationZipCode(countryName, zipcode));
        }
        #endregion
    }
}
