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
                    break;
                default:
                    ModelState.AddModelError("ContactType", "The selected Contact Type is not valid.");
                    break;
            }
            #endregion

            #region Document Number (CPF/CNPJ) Validation
            isValidDocumentNumber = DocumentNumber(contacts);
            if (!isValidDocumentNumber)
                ModelState.AddModelError("DocumentNumber", "The document number provided for this Contact Type is not valid.");
            #endregion

            #region Natural Person
            //Natural person: Name, CPF, Birthday, Gender and Address (ZipCode, Country, State, City, Address line 1 and Address line 2).

            #endregion

            #region Legal Person
            //Legal person: Company name, Trade name, CNPJ and Address (ZipCode, Country, State, City, Address line 1 and Address line 2).

            #endregion
        }

        /// <summary>
        /// Validate the Contact's document number according to the selected Contact Type
        /// </summary>
        /// <param name="contacts">Contacts object</param>
        /// <returns>Bollean indicating if is valid or not</returns>
        private static bool DocumentNumber(Contacts contacts)
        {
            //Validation through regex, checking first the document type (CPF or CNPJ) according to the selected Contact Type and getting the specifc regex for the returned document type
            return Regex.IsMatch(contacts.DocumentNumber, ContactRegexLib.Dictionary[ContactDocumentLib.Dictionary[contacts.ContactType.ToLower()]]);
        }
    }
}