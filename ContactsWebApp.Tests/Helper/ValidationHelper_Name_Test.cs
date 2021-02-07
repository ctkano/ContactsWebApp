using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ContactsWebApp.Helper.ValidationHelper;

namespace ContactsWebApp.Tests.Helper
{
    [TestClass]
    public class ValidationHelper_Name_Test
    {
        #region Correct Pattern
        /// <summary>
        /// Testing the validation of name for a correct name pattern
        /// </summary>
        [TestMethod]
        public void CorrectNamePatternValidationFirstTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationName getReturnValidationName = null;

            string name = "Cleyton Kano";

            getReturnValidationName = new GetReturnValidationName(validationHelper.ValidateName);
            Assert.IsTrue(getReturnValidationName(name));
        }

        /// <summary>
        /// Testing the validation of name for a correct name pattern
        /// </summary>
        [TestMethod]
        public void CorrectNamePatternValidationSecondTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationName getReturnValidationName = null;

            string name = "Cleyton D'Angelo";

            getReturnValidationName = new GetReturnValidationName(validationHelper.ValidateName);
            Assert.IsTrue(getReturnValidationName(name));
        }

        /// <summary>
        /// Testing the validation of name for a correct name pattern
        /// </summary>
        [TestMethod]
        public void CorrectNamePatternValidationThirdTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationName getReturnValidationName = null;

            string name = "Martin Luther King, Jr.";

            getReturnValidationName = new GetReturnValidationName(validationHelper.ValidateName);
            Assert.IsTrue(getReturnValidationName(name));
        }        

        /// <summary>
        /// Testing the validation of name for a correct name pattern
        /// </summary>
        [TestMethod]
        public void CorrectNamePatternValidationFourthTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationName getReturnValidationName = null;

            string name = "Hector Sausage-Hausen";

            getReturnValidationName = new GetReturnValidationName(validationHelper.ValidateName);
            Assert.IsTrue(getReturnValidationName(name));
        }

        /// <summary>
        /// Testing the validation of name for a correct name pattern
        /// </summary>
        [TestMethod]
        public void CorrectNamePatternValidationFithTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationName getReturnValidationName = null;

            string name = "Cláudia Salomão";

            getReturnValidationName = new GetReturnValidationName(validationHelper.ValidateName);
            Assert.IsTrue(getReturnValidationName(name));
        }
        #endregion

        #region Wrong Pattern
        /// <summary>
        /// Testing the validation of name for a wrong name pattern
        /// </summary>
        [TestMethod]
        public void WrongNamePatternValidationFirstTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationName getReturnValidationName = null;

            string name = "Cleyton K@no";

            getReturnValidationName = new GetReturnValidationName(validationHelper.ValidateName);
            Assert.IsFalse(getReturnValidationName(name));
        }

        /// <summary>
        /// Testing the validation of name for a wrong name pattern
        /// </summary>
        [TestMethod]
        public void WrongNamePatternValidationSecondTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationName getReturnValidationName = null;

            string name = "Cleyton_DAngelo";

            getReturnValidationName = new GetReturnValidationName(validationHelper.ValidateName);
            Assert.IsFalse(getReturnValidationName(name));
        }
        #endregion

        #region Null Information
        /// <summary>
        /// Testing the validation of name for a null information
        /// </summary>
        [TestMethod]
        public void NullValidationTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationName getReturnValidationName = null;

            string name = null;

            getReturnValidationName = new GetReturnValidationName(validationHelper.ValidateName);
            Assert.IsFalse(getReturnValidationName(name));
        }
        #endregion

        #region Empty Information
        /// <summary>
        /// Testing the validation of name for an empty information
        /// </summary>
        [TestMethod]
        public void EmptyValidationTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationName getReturnValidationName = null;

            string name = "";

            getReturnValidationName = new GetReturnValidationName(validationHelper.ValidateName);
            Assert.IsFalse(getReturnValidationName(name));
        }
        #endregion
    }
}
