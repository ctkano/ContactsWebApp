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
        /// Validate the Contact's document number according to the selected Contact Type
        /// </summary>
        /// <param name="contacts">Contacts object</param>
        /// <returns>Bollean indicating if is valid or not</returns>
        public static bool DocumentNumber(Contacts contacts)
        {
            //Validation through regex, checking first the document type (CPF or CNPJ) according to the selected Contact Type and getting the specifc regex for the returned document type
            return Regex.IsMatch(contacts.DocumentNumber, ContactRegexLib.Dictionary[ContactDocumentLib.Dictionary[contacts.ContactType.ToLower()]]);
        }
    }
}