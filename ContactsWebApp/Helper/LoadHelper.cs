using ContactsWebApp.Dictionary;
using ContactsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsWebApp.Helper
{
    public class LoadHelper
    {
        /// <summary>
        /// Load available countries from the Country's Library
        /// </summary>
        /// <returns>List of Countries ordered by country's name</returns>
        public static List<Country> Countries()
        {
            List<Country> countriesList = new List<Country>();

            //Get countries from Country's Library ordered by country's name
            foreach (KeyValuePair<string, string> countryLibReg in CountryLib.Dictionary.OrderBy(c => c.Key))
            {
                Country country = new Country 
                { 
                    Abreviation = countryLibReg.Value, 
                    Name = countryLibReg.Key 
                };

                countriesList.Add(country);
            }

            return countriesList;
        }
    }
}