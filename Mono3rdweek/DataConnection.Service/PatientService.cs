using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnection.Model;
using DataConnection.Repository;
using DataConnection.Repository.Common;
using DataConnection.Service.Common;

namespace DataConnection.Service
{
    public class PatientService : IPatientService
    {
        protected IPatientRepository PatientRepository { get; set; }

        public PatientService(IPatientRepository patientRepository)
        {
            PatientRepository = patientRepository;
        }

        public async Task<PatientModel> GetPatient(Guid id)
        {
            PatientModel patientModel = await PatientRepository.GetPatient(id);

            return patientModel;
        }

        public async Task<bool> AddNewPatient(PatientModel patient)
        {
            bool isAdded = await PatientRepository.AddNewPatient(patient);
            return isAdded;
        }

        public async Task<bool> EditPatient(Guid id, PatientModel patient)
        {
            PatientModel patientCheck = await PatientRepository.GetPatient(id);
            if (patientCheck == null)
            {
                return false;
            }
            PatientModel patientToEdit = new PatientModel
            {
                Id = id,
                Name = patient.Name == default ? patientCheck.Name : patient.Name,
                Surname = patient.Surname == default ? patientCheck.Surname : patient.Surname,
                DateOfBirth = patient.DateOfBirth == default ? patientCheck.DateOfBirth : patient.DateOfBirth,
                CityId = patient.CityId == default ? patientCheck.CityId : patient.CityId,
                Illness = patient.Illness == default ? patientCheck.Illness : patient.Illness


            };

            bool isEdited = await PatientRepository.EditPatient(id, patientToEdit);
            return isEdited;
        }

        public async Task<bool> DeletePatient(Guid id)
        {
            PatientModel patientCheck = await PatientRepository.GetPatient(id);
            if (patientCheck == null)
            {
                return false;
            }
            bool isDeleted = await PatientRepository.DeletePatient(id);
            return isDeleted;
        }
    }
}
