using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPractice.Models;

namespace WebApiPractice.Controllers
{
    public class HospitalController : ApiController
    {
        public static List<Hospital> Hospitals = new List<Hospital>
        {
            new Hospital
            {
                Id = 1,
                Name = "Osjecka bolnica",
                Address = new Address { City = "Osijek", PostalCode = 31000, StreetName = "Hutlerova 2" },
            },
            new Hospital
            {
                Id = 2,
                Name = "Zagrebacka bolnica",
                Address = new Address { City = "Zagreb", PostalCode = 10000, StreetName = "Sv. Petra 2" }

            }
        };
    }
}
