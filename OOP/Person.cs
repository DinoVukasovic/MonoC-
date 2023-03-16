using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public abstract class Person:IPerson
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public Address Address { get; set; }
        public string GetAddress()
        {
            return $"Address: {Address.City} {Address.State} {Address.Zip}";
        }


    }
}
