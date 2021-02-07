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
        /// <summary>
        /// Contact Information Validation
        /// </summary>
        /// <param name="ModelState">ModelState</param>
        /// <param name="contacts">Contacts</param>
        public static void ContactInformation(ModelStateDictionary ModelState, Contacts contacts)
        {
            #region Fields that must be null depending on Contact Type
            if (string.IsNullOrEmpty(contacts.ContactType))
                ModelState.AddModelError("DocumentNumber", "The Contact Type field is required.");
            else
            {
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
            }
            #endregion

            #region Document Number (CPF/CNPJ) Validation
            if(string.IsNullOrEmpty(contacts.DocumentNumber))
                ModelState.AddModelError("DocumentNumber", "The Document Number field is required.");
            else if (!IsValidDocumentNumber(contacts))
                ModelState.AddModelError("DocumentNumber", "The document number provided for this Contact Type is not valid.");
            #endregion

            #region Main Contact Name Validation
            if(string.IsNullOrEmpty(contacts.MainName))
                ModelState.AddModelError("MainName", "The Name / Company Name field is required.");
            else if (!IsValidContactName(contacts.MainName))
                ModelState.AddModelError("MainName", "The name provided is not valid.");
            #endregion

            #region Address Validation
            //Address (ZipCode, Country, State, City, Address line 1 and Address line 2)

            #region ZipCode
            if (!string.IsNullOrEmpty(contacts.ZipCode) && !IsValidZipCode(contacts.Country, contacts.ZipCode))
                    ModelState.AddModelError("ZipCode", "The zip code is not valid for the selected country.");
            #endregion

            #region State
            if (!string.IsNullOrEmpty(contacts.State) && !IsValidContactName(contacts.State))
                ModelState.AddModelError("State", "The state provided is not valid.");
            #endregion

            #region City
            if (!string.IsNullOrEmpty(contacts.City) && !IsValidContactName(contacts.City))
                ModelState.AddModelError("City", "The city provided is not valid.");
            #endregion

            #region AddressLine1
            if (!string.IsNullOrEmpty(contacts.AddressLine1) && !IsValidContactName(contacts.AddressLine1))
                ModelState.AddModelError("AddressLine1", "The Address Line 1 provided information is not valid.");
            #endregion

            #region AddressLine2
            if (!string.IsNullOrEmpty(contacts.AddressLine2) && !IsValidContactName(contacts.AddressLine2))
                ModelState.AddModelError("AddressLine3", "The Address Line 1 provided information is not valid.");
            #endregion

            #endregion
        }

        /// <summary>
        /// Validate the Contact's document number according to the selected Contact Type
        /// </summary>
        /// <param name="contacts">Contacts object</param>
        /// <returns>Bollean indicating if is valid or not according to the regular expression</returns>
        private static bool IsValidDocumentNumber(Contacts contacts)
        {
            if (string.IsNullOrEmpty(contacts.DocumentNumber))
                return false;
            else
                //Validation through regex, checking first the document type (CPF or CNPJ) according to the selected Contact Type and getting the specifc regex for the returned document type
                return Regex.IsMatch(contacts.DocumentNumber, ContactRegexLib.Dictionary[ContactDocumentLib.Dictionary[contacts.ContactType.ToLower()]]);
        }

        /// <summary>
        /// Validate the name to check any unusual characters
        /// Can be used to check Main Name, Trade Name, State, City, Address Line 1 and 2
        /// </summary>
        /// <param name="name">Name to be checked</param>
        /// <returns>Bollean indicating if is valid or not according to the regular expression</returns>
        private static bool IsValidContactName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;
            else
                //Validation through regex, following the international name standard
                return Regex.IsMatch(name, ContactRegexLib.Dictionary["name"]);
        }

        /// <summary>
        /// Validade the zip code provided according to the country's postal code pattern
        /// </summary>
        /// <param name="countryName">Country selected</param>
        /// <param name="zipcode">Zip Code provided</param>
        /// <returns>Bollean indicating if is valid or not according to the regular expression</returns>
        private static bool IsValidZipCode(string countryName, string zipcode)
        {
            if (string.IsNullOrEmpty(countryName) || string.IsNullOrEmpty(zipcode))
                return false;
            else
            {
                //Get the country abreviation
                string countryAbreviation = CountryLib.Dictionary[countryName];

                //Check if the zip code is valid for the country selected
                return Regex.IsMatch(zipcode, ZipCodeRegexLib.Dictionary[countryAbreviation]);
            }
        }

        /// <summary>
        /// Access to Document Number Validation
        /// </summary>
        /// <param name="contacts">Contacts</param>
        /// <returns>Bollean indicating if is valid or not according to the regular expression</returns>
        public delegate bool GetReturnValidationDocumentNumber(Contacts contacts);

        /// <summary>
        /// Access to Document Number Validation
        /// </summary>
        public GetReturnValidationDocumentNumber ValidateDocumentNumber
        {
            get
            {
                return new GetReturnValidationDocumentNumber(IsValidDocumentNumber);
            }
        }

        /// <summary>
        /// Access to Name Validation
        /// </summary>
        /// <param name="name">Name to be checked</param>
        /// <returns>Bollean indicating if is valid or not according to the regular expression</returns>
        public delegate bool GetReturnValidationName(string name);

        /// <summary>
        /// Access to Name Validation
        /// </summary>
        public GetReturnValidationName ValidateName
        {
            get
            {
                return new GetReturnValidationName(IsValidContactName);
            }
        }

        /// <summary>
        /// Access to Zip Code Validation
        /// </summary>
        /// <param name="countryName">Country selected</param>
        /// <param name="zipcode">Zip Code provided</param>
        /// <returns>Bollean indicating if is valid or not according to the regular expression</returns>
        public delegate bool GetReturnValidationZipCode(string countryName, string zipcode);

        /// <summary>
        /// Access to Zip Code Validation
        /// </summary>
        public GetReturnValidationZipCode ValidateZipCode
        {
            get
            {
                return new GetReturnValidationZipCode(IsValidZipCode);
            }
        }
    }
}