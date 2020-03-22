using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseNETCore.Model
{
    public class Person
    {
        private Person()
        {
            // EF
        }

        public static Person Create(int id,string firstName,string midleName,string lastName,string telephonNumber)
        {
            return new Person
            {
                Id = id,
                FirstName = firstName,
                MidleName = midleName,
                LastName = lastName,
                TelephonNumber = telephonNumber
            };
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MidleName { get; set; }
        public string LastName { get; set; }

        public string TelephonNumber { get; set; }
    }
}
