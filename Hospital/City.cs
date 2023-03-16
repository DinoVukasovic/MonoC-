using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Patient> Patients { get; set; }
        public List<Hospital> Hospitals { get; set; }

    }
}
