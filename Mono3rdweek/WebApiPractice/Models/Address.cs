using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPractice.Models
{
    public class Address
    {
        
        public string City { get; set; }
        public string StreetName { get; set; }

        public int PostalCode { get; set; }
    }
}