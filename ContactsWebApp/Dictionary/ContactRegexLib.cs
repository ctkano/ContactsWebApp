using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsWebApp.Dictionary
{
    public class ContactRegexLib
    {
        /// <summary>
        /// Dictionary Interface
        /// </summary>
        public static IDictionary<string, string> Dictionary;

        /// <summary>
        /// Convertion from a text level selected by the user to a correspondent number
        /// 
        /// Usage: ContactRegexLib.Dictionary[string regexName];
        /// 
        /// Dictionary parameters:
        /// string, int
        /// regexName, regex
        /// </summary>
        static ContactRegexLib()
        {
            Dictionary = new Dictionary<string, string>()
            {
                {"CPF", "(^\\d{3}\\x2E\\d{3}\\x2E\\d{3}\\x2D\\d{2}$)"},
                {"CNPJ", "\\d{2}.?\\d{3}.?\\d{3}/?\\d{4}-?\\d{2}"}
            };
        }
    }
}