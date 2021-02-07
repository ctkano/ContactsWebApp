using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ContactsWebApp.Helper.ValidationHelper;

namespace ContactsWebApp.Tests.Helper
{
    [TestClass]
    public class ValidationHelper_DocumentNumber_Test
    {
        #region CPF
        /// <summary>
        /// Testing the validation of document number for a correct CPF pattern
        /// </summary>
        [TestMethod]
        public void CorrectCPFPatternValidationTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationDocumentNumber getReturnValidationDocumentNumber = null;

            ContactsWebApp.Models.Contacts contacts = new Models.Contacts();
            contacts.ContactType = "Natural Person";
            contacts.DocumentNumber = "999.999.999-99";

            getReturnValidationDocumentNumber = new GetReturnValidationDocumentNumber(validationHelper.ValidateDocumentNumber);
            Assert.IsTrue(getReturnValidationDocumentNumber(contacts));
        }

        /// <summary>
        /// Testing the validation of document number for a wrong CPF pattern
        /// </summary>
        [TestMethod]
        public void WrongCPFPatternValidationTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationDocumentNumber getReturnValidationDocumentNumber = null;

            ContactsWebApp.Models.Contacts contacts = new Models.Contacts();
            contacts.ContactType = "Natural Person";
            contacts.DocumentNumber = "99.999.999/9991-99";

            getReturnValidationDocumentNumber = new GetReturnValidationDocumentNumber(validationHelper.ValidateDocumentNumber);
            Assert.IsFalse(getReturnValidationDocumentNumber(contacts));
        }
        #endregion

        #region CNPJ
        /// <summary>
        /// Testing the validation of document number for a correct CNPJ pattern
        /// </summary>
        [TestMethod]
        public void CorrectCNPJPatternValidationTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationDocumentNumber getReturnValidationDocumentNumber = null;

            ContactsWebApp.Models.Contacts contacts = new Models.Contacts();
            contacts.ContactType = "Legal Person";
            contacts.DocumentNumber = "99.999.999/9991-99";

            getReturnValidationDocumentNumber = new GetReturnValidationDocumentNumber(validationHelper.ValidateDocumentNumber);
            Assert.IsTrue(getReturnValidationDocumentNumber(contacts));
        }

        /// <summary>
        /// Testing the validation of document number for a wrong CNPJ pattern
        /// </summary>
        [TestMethod]
        public void WrongCNPJPatternValidationTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationDocumentNumber getReturnValidationDocumentNumber = null;

            ContactsWebApp.Models.Contacts contacts = new Models.Contacts();
            contacts.ContactType = "Legal Person";
            contacts.DocumentNumber = "999.999.999-99";

            getReturnValidationDocumentNumber = new GetReturnValidationDocumentNumber(validationHelper.ValidateDocumentNumber);
            Assert.IsFalse(getReturnValidationDocumentNumber(contacts));
        }
        #endregion

        #region Null Information
        /// <summary>
        /// Testing the validation of document number for a null document number information
        /// </summary>
        [TestMethod]
        public void NullValidationTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationDocumentNumber getReturnValidationDocumentNumber = null;

            ContactsWebApp.Models.Contacts contacts = new Models.Contacts();
            contacts.ContactType = "Natural Person";
            contacts.DocumentNumber = null;

            getReturnValidationDocumentNumber = new GetReturnValidationDocumentNumber(validationHelper.ValidateDocumentNumber);
            Assert.IsFalse(getReturnValidationDocumentNumber(contacts));
        }
        #endregion

        #region Empty Information
        /// <summary>
        /// Testing the validation of document number for an empty document number information
        /// </summary>
        [TestMethod]
        public void EmptyValidationTest()
        {
            ContactsWebApp.Helper.ValidationHelper validationHelper = new ContactsWebApp.Helper.ValidationHelper();
            GetReturnValidationDocumentNumber getReturnValidationDocumentNumber = null;

            ContactsWebApp.Models.Contacts contacts = new Models.Contacts();
            contacts.ContactType = "Natural Person";
            contacts.DocumentNumber = "";

            getReturnValidationDocumentNumber = new GetReturnValidationDocumentNumber(validationHelper.ValidateDocumentNumber);
            Assert.IsFalse(getReturnValidationDocumentNumber(contacts));
        }
        #endregion
    }
}
