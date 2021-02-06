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
        public static List<Country> Countries()
        {
            List<Country> countriesList = new List<Country>();

            foreach(KeyValuePair<string, string> countryLibReg in CountryLib.Dictionary.OrderBy(c => c.Key))
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