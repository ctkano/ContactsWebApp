﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsWebApp.Dictionary
{
    public class ContactRegexLib
    {
        /// <summary>
        /// Interface to get the Regex for the specified Regex Key Word
        /// Usage: ContactRegexLib.Dictionary[string regexKeyWord];
        /// </summary>
        public static IDictionary<string, string> Dictionary;

        /// <summary>
        /// Regex list for the specified Regex Key Word
        /// 
        /// Dictionary parameters:
        /// string, int
        /// regexKeyWord, regex
        /// </summary>
        static ContactRegexLib()
        {
            Dictionary = new Dictionary<string, string>()
            {
                {"cpf", "(^\\d{3}\\x2E\\d{3}\\x2E\\d{3}\\x2D\\d{2}$)"},
                {"cnpj", "\\d{2}.?\\d{3}.?\\d{3}/?\\d{4}-?\\d{2}"},
                {"name","^[a-zA-Z0-9àáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$"}
            };
        }
    }
}