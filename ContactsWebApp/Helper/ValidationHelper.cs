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
                    if (contacts.TradeName != null && !IsValidContactName(contacts.TradeName))
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
            #region ZipCode
            if (contacts.ZipCode != null && !IsValidZipCode(contacts.Country, contacts.ZipCode))
                    ModelState.AddModelError("ZipCode", "The zip code is not valid for the selected country.");
            #endregion
            #region State
            if (contacts.State != null && !IsValidContactName(contacts.State))
                ModelState.AddModelError("State", "The state provided is not valid.");
            #endregion
            #region City
            if (contacts.City != null && !IsValidContactName(contacts.City))
                ModelState.AddModelError("City", "The city provided is not valid.");
            #endregion
            #region AddressLine1
            if (contacts.AddressLine1 != null && !IsValidContactName(contacts.AddressLine1))
                ModelState.AddModelError("AddressLine1", "The Address Line 1 provided information is not valid.");
            #endregion
            #region AddressLine2
            if (contacts.AddressLine2 != null && !IsValidContactName(contacts.AddressLine2))
                ModelState.AddModelError("AddressLine3", "The Address Line 1 provided information is not valid.");
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

        private static bool IsValidZipCode(string countryName, string zipcode)
        {
            //Get the country abreviation
            string countryAbreviation = CountryLib.Dictionary[countryName];

            //Check if the zip code is valid for the country selected
            return Regex.IsMatch(zipcode, PostalCodeRegexLib.Dictionary[countryAbreviation]);
        }
    }
}