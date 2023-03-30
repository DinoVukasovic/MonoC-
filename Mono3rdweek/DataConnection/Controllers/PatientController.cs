using DataConnection.Model;
using DataConnection.Service;
using DataConnection.Service.Common;
using DataConnection.WebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataConnection.Controllers
{
    public class PatientController : ApiController
    {
        protected IPatientService PatientService { get; set; }

        public PatientController (IPatientService patientService)
        {
            PatientService = patientService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetPatient(Guid id)
        {
            PatientModel patient = await PatientService.GetPatient(id);
            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to find that Patient.");
            }
            PatientRest patientRest = new PatientRest();
            patientRest.Name = patient.Name;
            patientRest.Surname = patient.Surname;
            return Request.CreateResponse(HttpStatusCode.OK, patientRest);
        }

        [HttpPost]

        public async Task<HttpResponseMessage> AddNewPatient(PatientPostRest patientRest)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            PatientModel patientModel = new PatientModel();
            patientModel.Name = patientRest.Name;
            patientModel.Surname = patientRest.Surname;
            patientModel.DateOfBirth = patientRest.DateOfBirth;
            patientModel.CityId = patientRest.CityId;
            patientModel.Illness = patientRest.Illness;

            bool isAdded = await PatientService.AddNewPatient(patientModel);
            if (!isAdded)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Unable to add new Patient.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Added new Patient successfully.");
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeletePatient(Guid id)
        {
            bool isDeleted = await PatientService.DeletePatient(id);
            if (!isDeleted)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to delete Patient.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Patient deleted successfully.");
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdatePatient(Guid id, PatientPutRest patientRest)
        {
            PatientModel patientModel = new PatientModel();
            patientModel.Name = patientRest.Name;
            patientModel.Surname = patientRest.Surname;
   

            bool isEdited = await PatientService.EditPatient(id, patientModel);
            if (!isEdited)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Unable to update patient.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Patient updated successfully.");
        }

        public class PatientPostRest
        {
            public string Name { get; set; }
            public string Surname { get; set;}

            public DateTime DateOfBirth { get; set;}

            public Guid CityId { get; set;}

            public string Illness { get; set;}
        }

        public class PatientPutRest
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
