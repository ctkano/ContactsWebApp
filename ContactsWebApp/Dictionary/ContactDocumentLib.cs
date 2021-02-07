using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsWebApp.Dictionary
{
    public class ContactDocumentLib
    {
        /// <summary>
        /// Interface to get the Document Type for the specified Contact Type
        /// Usage: ContactDocumentLib.Dictionary[string contactType];
        /// </summary>
        public static IDictionary<string, string> Dictionary;

        /// <summary>
        /// Document Type for the specified Contact Type
        /// 
        /// Dictionary parameters:
        /// string, int
        /// regexName, regex
        /// </summary>
        static ContactDocumentLib()
        {
            Dictionary = new Dictionary<string, string>()
            {
                {"natural person", "cpf"},
                {"legal person", "cnpj"}
            };
        }
    }
}