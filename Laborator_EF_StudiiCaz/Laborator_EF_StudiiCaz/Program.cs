using System;
using System.Linq;

namespace Laborator_EF_StudiiCaz
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelSelfRefrences references = new ModelSelfRefrences();
            //SelfReference reference = new SelfReference(3, "Treia");
            //references.SelfReferences.Add(reference);
            //references.SaveChanges();

            /*Referinta2 are acum o referinta spre referinta1*/
            //SelfReference reference1 = references.SelfReferences.FirstOrDefault(a => a.SelfReferenceId == 1);
            //SelfReference reference2 = references.SelfReferences.FirstOrDefault(a => a.SelfReferenceId == 2);
            //reference2.ParentSelfReference = reference1

            /*Referinta3 are acum o referinta spre referinta2*/
            SelfReference reference3 = references.SelfReferences.FirstOrDefault(a => a.SelfReferenceId == 3);
            SelfReference reference2 = references.SelfReferences.FirstOrDefault(a => a.SelfReferenceId == 2);
            reference3.ParentSelfReference = reference2;

            references.SaveChanges();

        }
    }
}
