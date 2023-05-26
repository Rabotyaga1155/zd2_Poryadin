using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika2
{
    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }

       
        public Contact (string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public override string ToString ()
        {
            return $"{Name} - {Phone}";
        }
    }
}
