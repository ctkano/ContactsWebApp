using ContactsWebApp.Dictionary;
using ContactsWebApp.Models;
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
        /// Validate the Contact's document number according to the Contact Type selected
        /// </summary>
        /// <param name="contacts">Contacts object</param>
        /// <returns>Bollean indicating if is valid or not</returns>
        public static bool DocumentNumber(Contacts contacts)
        {
            #region Initialization
            bool isValidDocumentNumber = false;
            string regex = string.Empty;
            #endregion

            #region Validation
            regex = ContactRegexLib.Dictionary[ContactDocumentLib.Dictionary[contacts.ContactType]];
            isValidDocumentNumber = Regex.IsMatch(contacts.DocumentNumber, regex);
            #endregion

            return isValidDocumentNumber;
        }
    }
}