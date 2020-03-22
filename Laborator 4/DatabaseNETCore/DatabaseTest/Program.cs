using DatabaseNETCore.ModelContext;
using System;
using System.Linq;

namespace DatabaseNETCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            PersonContext personContext = new PersonContext();

            var myList = personContext.Persons.ToList();

            foreach (var person in myList)
            {
                Console.WriteLine($"{person.Id} {person.FirstName} {person.MidleName} {person.LastName} {person.TelephonNumber}");
            }

            Console.ReadLine();
        }
    }
}
