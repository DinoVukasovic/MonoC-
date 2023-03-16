using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid HospitalId { get; set; }
        public Guid DoctorId { get; set; }

        public Hospital hospital { get; set; }

        public Doctor Doctor { get; set; }

    }
}
