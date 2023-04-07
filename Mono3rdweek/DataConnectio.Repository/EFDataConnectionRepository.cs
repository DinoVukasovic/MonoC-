using DataConnection.DAL;
using DataConnection.Model;
using DataConnection.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnectio.Repository
{
    internal class EFPatientRepository : IPatientRepository
    {
        public HospitalContext Context { get; set; }
        public EFPatientRepository(HospitalContext context)
        {
            Context = context;
        }
        public Task<bool> AddNewPatient(PatientModel patient)
        {
            throw new NotImplementedException();
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
