using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using WebApiPractice.Models;

namespace WebApiPractice.Controllers
{
    public class PatientController : ApiController
    {
        public bool IsSuccess { get; set; }

        public static List<Patient> Patients = new List<Patient>
        {   new Patient {Id = 1, FirstName = "Dino", 
            LastName = "Dinic", 
            DateOfBirth = DateTime.Now.Date, 
            Address = new Address {City = "Osijek", PostalCode = 31000, StreetName ="Cetinska 12" },
            HospitalId = 1},

            new Patient {Id = 2, FirstName = "Marko",
            LastName = "Markic",
            DateOfBirth = DateTime.Now.Date,
            Address = new Address {City = "Zagreb", PostalCode = 10000, StreetName ="Opatijsk 14" },
            HospitalId = 2},

            new Patient {Id = 3, FirstName = "Ivo",
            LastName = "Ivic",
            DateOfBirth = DateTime.Now.Date,
            Address = new Address {City = "Zagreb", PostalCode = 10000, StreetName ="Hutlerova 2" },
            HospitalId = 2}

        };

        [HttpGet]
        public List<Patient> GetPatients() 
        {
            return Patients;
        }

        [HttpGet]
        public Patient GetPatient(int id)
        {

            Patient returnPatient = Patients.Find(p => p.Id == id);
            return returnPatient;
        }

        [HttpDelete] 
        public void DeletePatient(int id) 
        {
           
            Patient patientDelete = Patients.Find(p => p.Id == id);
            try
            {
                Patients.Remove(patientDelete);
                IsSuccess = true;
            }
            catch (Exception)
            {
                IsSuccess = false;
            }
            
        }

        [HttpPost]
        public List<Patient> CreatePatient([FromBody] Patient patient)
        {
            try
            {
                Patients.Add(patient);
                IsSuccess = true;
            }
            catch (Exception)
            {
                IsSuccess = false;
            }
            return Patients;
        }


    }
}
