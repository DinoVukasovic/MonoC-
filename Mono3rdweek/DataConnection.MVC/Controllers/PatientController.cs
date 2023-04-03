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
            PatientModel patient = await PatientService.GetPatient(id.Value );
            if (patient == null)
            {
                return View("Error");
            }
            PatientRest patientRest = new PatientRest();
            patientRest.Name = patient.Name;
            patientRest.Surname = patient.Surname;
            return View(patientRest);
        }
    }
}