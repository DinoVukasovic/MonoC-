using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnection.Model;
using DataConnection.Common;

namespace DataConnection.Repository.Common
{
    public interface IPatientRepository
    {
        Task<PatientModel> GetPatient(Guid id);
        Task<bool> AddNewPatient(PatientModel patient);
        Task<bool> EditPatient(Guid id, PatientModel patient);
        Task<bool> DeletePatient(Guid id);
    }
}
