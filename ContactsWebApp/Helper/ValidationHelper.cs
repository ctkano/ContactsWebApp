using ContactsWebApp.Dictionary;
using ContactsWebApp.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ContactsWebApp.Helper
{
    public class ValidationHelper
    {
        public static void ContactInformation(ModelStateDictionary ModelState, Contacts contacts)
        {
            #region Initialization
            bool isValidDocumentNumber = false;
            #endregion

            #region Fields that must be null depending on Contact Type
            switch (contacts.ContactType.ToLower())
            {
                case "natural person":
                    contacts.TradeName = null;
                    break;
                case "legal person":
                    contacts.Birthday = null;
                    contacts.Gender = null;
                    if (!IsValidContactName(contacts.TradeName))
                        ModelState.AddModelError("TradeName", "The trade name provided is not valid.");
                    break;
                default:
                    ModelState.AddModelError("ContactType", "The selected Contact Type is not valid.");
                    break;
            }
            #endregion

            #region Document Number (CPF/CNPJ) Validation
            if (!IsValidDocumentNumber(contacts))
                ModelState.AddModelError("DocumentNumber", "The document number provided for this Contact Type is not valid.");
            #endregion

            #region Main Contact Name Validation
            if(!IsValidContactName(contacts.MainName))
                ModelState.AddModelError("MainName", "The name provided is not valid.");
            #endregion

            #region Address Validation
            //Address (ZipCode, Country, State, City, Address line 1 and Address line 2)
            #region Line 1

            #endregion
            #region Line 2

            #endregion
            #endregion
        }

        /// <summary>
        /// Validate the Contact's document number according to the selected Contact Type
        /// </summary>
        /// <param name="contacts">Contacts object</param>
        /// <returns>Bollean indicating if is valid or not</returns>
        private static bool IsValidDocumentNumber(Contacts contacts)
        {
            //Validation through regex, checking first the document type (CPF or CNPJ) according to the selected Contact Type and getting the specifc regex for the returned document type
            return Regex.IsMatch(contacts.DocumentNumber, ContactRegexLib.Dictionary[ContactDocumentLib.Dictionary[contacts.ContactType.ToLower()]]);
        }

        private static bool IsValidContactName(string name)
        {
            //Validation through regex, following the international name standard
            return Regex.IsMatch(name, ContactRegexLib.Dictionary["name"]);
        }
    }
}