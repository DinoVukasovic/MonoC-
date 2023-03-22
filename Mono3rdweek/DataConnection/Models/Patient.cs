using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataConnection.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid CityId { get; set; }
        public string Illness { get; set; }

        
    }
}