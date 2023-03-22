using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPractice.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int HospitalId { get; set; }

        public Address Address { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nFirst Name: {FirstName}\nLast Name: {LastName}\nDOB: {DateOfBirth}\nHospitalId: {HospitalId}";
        }
    }
}