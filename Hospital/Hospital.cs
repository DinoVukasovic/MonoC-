using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Hospital
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }
        public string Address { get; set; }

        public City City { get; set; }
        public List<Department> Departments { get; set; }

    }
}
