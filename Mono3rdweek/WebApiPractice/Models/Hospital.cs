using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPractice.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}