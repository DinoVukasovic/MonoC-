using DataConnection.Repository.Common;
using DataConnection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using DataConnection.DAL;

namespace DataConnection.Repository
{
    public class EFPatientRepository : IPatientRepository
    {
        public HospitalContext Context { get; set; }
        public EFPatientRepository(HospitalContext context)
        {
            Context = context;
        }
        public async Task<bool> AddNewPatient(PatientModel patient)
        {
            try
            {
                if (patient != null)
                {
                    Patient patientDal = new Patient
                    {
                        Id = Guid.NewGuid(),
                        Name = patient.Name,
                        Surname = patient.Surname,
                        CityId = patient.CityId,
                        DateOfBirth = patient.DateOfBirth,
                        Illnness = patient.Illness
                    };
                    Context.Patients.Add(patientDal);
                    await Context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> DeletePatient(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditPatient(Guid id, PatientModel patient)
        {
            throw new NotImplementedException();
        }

        public Task<PatientModel> GetPatient(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
