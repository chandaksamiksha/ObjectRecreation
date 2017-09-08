using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Person
    {
       
        public string Name { get; set; }
        public string Surname { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public long MobileNumber { get; set; }
        public string Town { get; set; }

        public Person(string name, string surname, DateTime dob, long mobilenumber, string town)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dob;
            MobileNumber=mobilenumber;
            Town = town;

        }

        
    }
}
