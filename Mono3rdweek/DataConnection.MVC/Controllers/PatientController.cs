using DataConnection.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using DataConnection.Model;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using DataConnection.MVC.Models;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using HttpDeleteAttribute = System.Web.Mvc.HttpDeleteAttribute;
using DataConnection.DAL;

namespace DataConnection.MVC.Controllers
{
    public class PatientController : Controller
    {
       

        protected IPatientService PatientService { get; set; }

        public PatientController(IPatientService patientService)
        {
            PatientService = patientService;
        }

        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetPatient(Guid? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            PatientModel patient = await PatientService.GetPatient(id.Value);
            if (patient == null)
            {
                return View("Error");
            }
            PatientRest patientRest = new PatientRest();
            patientRest.Name = patient.Name;
            patientRest.Surname = patient.Surname;
            return View(patientRest);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewPatient (PatientRest patient)
        {
            if (patient == null)
            {
                return View("Error");
            }

            PatientModel patientModel = new PatientModel();
            patientModel.Name = patient.Name;
            patientModel.Surname = patient.Surname;
            patientModel.DateOfBirth = patient.DateOfBirth;
            patientModel.CityId = patient.CityId;
            patientModel.Illness = patient.Illness;

            bool isAdded = await PatientService.AddNewPatient(patientModel);
            if (!isAdded)
            {
                return View("Error");
            }
            return View(patient);
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePatient(Guid id)
        {
            try
            {
                PatientModel patientModel = await PatientService.GetPatient(id);
                if (patientModel == null)
                {
                    return View("Error");
                }
                PatientRest patientRest = new PatientRest
                {
                    Name = patientModel.Name,
                    Surname = patientModel.Surname,
                    Id = id
                   
                };
                return View(patientRest);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

    }

    
}