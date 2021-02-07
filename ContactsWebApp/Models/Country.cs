using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsWebApp.Models
{
    public class Country
    {
        /// <summary>
        /// Country Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Country's Name Abreviation
        /// </summary>
        public string Abreviation { get; set; }

        /// <summary>
        /// Name of the Country
        /// </summary>
        public string Name { get; set; }
    }
}