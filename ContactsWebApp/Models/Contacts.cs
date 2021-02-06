using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactsWebApp.Models
{
    public class Contacts
    {
        public int Id { get; set; }

        /// <summary>
        /// Represents the Type of the contact, the value should be: Natural person or Legal person
        /// </summary>
        [Required]
        [DisplayName("Contact Type")]
        public string ContactType { get; set; }

        /// <summary>
        /// Represents the Name for Natual person and the Company name for Legal person
        /// </summary>
        [Required]
        [DisplayName("Name / Company Name")]
        public string MainName { get; set; }

        /// <summary>
        /// Represents the Trade Name, available only for Legal person
        /// </summary>
        [DisplayName("Trade Name")]
        public string TradeName { get; set; }

        /// <summary>
        /// Represents the CPF for Natual person and the CNPJ for Legal person
        /// </summary>
        [Required]
        [DisplayName("Document Number")]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Represents the Birthday, available only for Natural person
        /// </summary>
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Represents the Gender, available only for Natural person
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Represents the address first line of the contact
        /// </summary>
        [DisplayName("Address Line 1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Represents the address second line for additional address information of the contact
        /// </summary>
        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }
    }
}