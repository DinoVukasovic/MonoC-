using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnection.Model.Common
{
    public interface IPatientModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        DateTime DateOfBirth { get; set; }
        Guid CityId { get; set; }
        string Illness { get; set; }
    }
}
