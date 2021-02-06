using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsWebApp.Dictionary
{
    public class ContactDocumentLib
    {
        /// <summary>
        /// Dictionary Interface
        /// </summary>
        public static IDictionary<string, string> Dictionary;

        /// <summary>
        /// Get the Document Type for the specified Contact Type
        /// 
        /// Usage: ContactDocumentLib.Dictionary[string contactType];
        /// 
        /// Dictionary parameters:
        /// string, int
        /// regexName, regex
        /// </summary>
        static ContactDocumentLib()
        {
            Dictionary = new Dictionary<string, string>()
            {
                {"Natural Person", "CPF"},
                {"Legal Person", "CNPJ"}
            };
        }
    }
}