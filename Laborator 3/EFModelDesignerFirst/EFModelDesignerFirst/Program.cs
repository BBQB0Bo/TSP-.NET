using System;

namespace EFModelDesignerFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Model1Container context = new Model1Container())
            {
                PersonDesignFirst p = new PersonDesignFirst()
                {
                    FirstName = "Julie",
                    LastName = "Andrew",
                    MidleName = "T",
                    TelephonNumber = "1234567890"
                };

                context.PersonDesignFirsts.Add(p);
                context.SaveChanges();
                var items = context.PersonDesignFirsts;
                foreach (var x in items)
                    Console.WriteLine("{0} {1}", x.Id, x.FirstName);
            }
        }
    }
}
