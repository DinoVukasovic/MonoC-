using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public interface IPerson
    {
        string Name { get; set; }
        string LastName { get; set; }


        string GetAddress();
    }
}
