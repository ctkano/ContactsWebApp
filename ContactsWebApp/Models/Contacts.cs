using System;
using System.Collections.Generic;
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
        public string ContactType { get; set; }

        /// <summary>
        /// Represents the Name for Natual person and the Company name for Legal person
        /// </summary>
        [Required]
        public string MainName { get; set; }

        /// <summary>
        /// Represents the Trade Name, available only for Legal person
        /// </summary>
        public string TradeName { get; set; }

        /// <summary>
        /// Represents the CPF for Natual person and the CNPJ for Legal person
        /// </summary>
        [Required]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Represents the Birthday, available only for Natural person
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Represents the Gender, available only for Natural person
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Represents the address of the contact
        /// </summary>
        public string Address { get; set; }
    }
}