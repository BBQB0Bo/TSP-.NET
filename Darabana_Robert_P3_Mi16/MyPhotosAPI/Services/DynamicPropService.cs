using DataBaseLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotosAPI.Services
{
    public class DynamicPropService
    {
        public readonly MyPhotosModelContainer context;

        public DynamicPropService()
        {
            this.context = new MyPhotosModelContainer();
        }

        public int GetMaxId()
        {
            var maxId = 0;
            if (context.DynamicProprieties.Count() == 0)
                maxId = 0;
            else
                maxId = context.DynamicProprieties.Max(a => a.Id); //Aflam id-ul maxim curent din tabelul DynamicProprieties , ca sa il folosim ulterior.

            return maxId;
        }

        /*Functie prin care adaugam dinamic o proprietate in tabelulul DynamicPropriety*/
        public void AddDynamicProp(string fullPath, string proprietyName, string proprietyValue)
        {
            string absPath = Path.GetFullPath(fullPath);
            var result = context.Files.FirstOrDefault(a => a.FullPath == absPath);

            if (result != null)
            {
                DynamicPropriety propriety = new DynamicPropriety();
                int propAlreadyExist = 0;
                foreach (DynamicPropriety prop in context.DynamicProprieties)
                {
                    if (prop.ProprietyName.Equals(proprietyName) && prop.ProprietyValue.Equals(proprietyValue))
                    {
                        propAlreadyExist = 1;
                        propriety = prop;
                        break;
                    }
                }
                if (propAlreadyExist == 1)
                {
                    result.AddDynamicProp(propriety);
                }
                else
                {
                    DynamicPropriety propriety1 = new DynamicPropriety(GetMaxId() + 1, proprietyName, proprietyValue);
                    result.AddDynamicProp(propriety1);
                }
                context.SaveChanges();
            }
        }

        /*Functie prin care stergem o proprietare dinamica cu un anumit nume de la un File - fullPath*/
        public void DeleteDynamicProp(string fullPath, string propName)
        {

            DataBaseLibrary.File file = context.Files.Include("DynamicProprieties").FirstOrDefault(a => a.FullPath.Equals(fullPath));

            int number = file.DynamicProprieties.Count(a => a.ProprietyName.Equals(propName));

            while (number > 0)
            {
                foreach (DynamicPropriety dp in file.DynamicProprieties)
                {
                    if (dp.ProprietyName.Equals(propName))
                    {
                        file.DynamicProprieties.Remove(dp);
                        break;
                    }
                }

                number--;
            }

            context.SaveChanges();
        }

        /*Functie prin care dam update la proprietare dinamica cu un anumit nume si o anumita descriere de la un File - fullPath*/
        public void UpdateDynamicProp(string fullPath, string propName, string oldPropValue, string newPropValue)
        {
            DataBaseLibrary.File file = context.Files.Include("DynamicProprieties").FirstOrDefault(a => a.FullPath.Equals(fullPath));

            foreach (DynamicPropriety dp in file.DynamicProprieties)
            {
                if (dp.ProprietyName.Equals(propName) && dp.ProprietyValue.Equals(oldPropValue))
                    dp.ProprietyValue = newPropValue;
            }

            context.SaveChanges();
        }

        /*Functie prin care afisam toate proprietatile dinamice pentru o poza*/
        public List<DynamicPropriety> returnDynamicProps(string fullPath)
        {
            List<DynamicPropriety> dynamicProps = new List<DynamicPropriety>();
            DataBaseLibrary.File file = context.Files.Include("DynamicProprieties").FirstOrDefault(a => a.FullPath.Equals(fullPath));

            foreach (DynamicPropriety dp in file.DynamicProprieties)
                dynamicProps.Add(dp);

            return dynamicProps;
        }

        /*Functie prin care afisam toate proprietatile dinamice*/
        public List<DynamicPropriety> allDynamicProps()
        {
            return context.DynamicProprieties.Distinct().ToList();
        }

    }
}
