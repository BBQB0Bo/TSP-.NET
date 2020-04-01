using DataBaseLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotosAPI.Services
{
    public class ProprietyService
    {
        public readonly MyPhotosModelContainer context;

        public ProprietyService()
        {
            this.context = new MyPhotosModelContainer();
        }

        /*Returneaza proprietatile pentru un path*/
        public Propriety returnPropriety(string fullPath)
        {
            var result = context.Files.FirstOrDefault(a => a.FullPath == fullPath);
            return result.Propriety;
        }

        /*String in DataTime*/
        public static DateTime returnDateTime(string date)
        {
            string[] dateParts = date.Split('-');
            int an = 0, luna = 0, zi = 0;
            try
            {
                an = Int32.Parse(dateParts[0]);
                luna = Int32.Parse(dateParts[1]);
                zi = Int32.Parse(dateParts[2]);

            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse");
            }

            return new DateTime(an, luna, zi);
        }

        /*Definim procedurile prin care modificam anumite proprietati*/

        /*Update Data Creare*/
        /*Formatul de data este urmatorul an-luna-zi*/
        public void updateDateTime(string fullPath, string date)
        {
            DateTime dateTime = returnDateTime(date);
            string absPath = Path.GetFullPath(fullPath);
            var result = context.Files.FirstOrDefault(a => a.FullPath == absPath);

            if (result != null)
            {
                result.Propriety.DataCreated = dateTime;
                context.SaveChanges();
            }
        }

        /*Update Eveniment*/
        public void updateEvent(string fullPath, string eve)
        {
            string absPath = Path.GetFullPath(fullPath);
            var result = context.Files.FirstOrDefault(a => a.FullPath == absPath);

            if (result != null)
            {
                result.Propriety.Event = eve;
                context.SaveChanges();
            }
        }

        /*Update Persoane*/
        /*Formatul persoanelor este Nume,Nume,Nume sau pur si simplu Nume*/
        public void updatePeople(string fullPath, string people)
        {
            string absPath = Path.GetFullPath(fullPath);
            var result = context.Files.FirstOrDefault(a => a.FullPath == absPath);

            if (result != null)
            {
                result.Propriety.People = people;
                context.SaveChanges();
            }
        }

        /*Update Peisaje*/
        /*Formatul peisajelor este Peisaj,Peisaj,Peisaj sau pur si simplu Peisaj*/
        public void updateLandscapes(string fullPath, string landscapes)
        {
            string absPath = Path.GetFullPath(fullPath);
            var result = context.Files.FirstOrDefault(a => a.FullPath == absPath);

            if (result != null)
            {
                result.Propriety.Landscapes = landscapes;
                context.SaveChanges();
            }
        }

        /*Update Loc Fotografie*/
        public void updatePhotoPlace(string fullPath, string photoPlace)
        {
            string absPath = Path.GetFullPath(fullPath);
            var result = context.Files.FirstOrDefault(a => a.FullPath == absPath);

            if (result != null)
            {
                result.Propriety.Photoplace = photoPlace;
                context.SaveChanges();
            }
        }

        /*Updatare toate deodata*/
        public void updateAll(string fullPath, string date, string eve, string people, string landscapes, string photoPlace)
        {
            string absPath = Path.GetFullPath(fullPath);
            DateTime dateTime = returnDateTime(date);
            var result = context.Files.FirstOrDefault(a => a.FullPath == absPath);
            if (result != null)
            {
                result.Propriety.DataCreated = dateTime;
                result.Propriety.Event = eve;
                result.Propriety.People = people;
                result.Propriety.Landscapes = landscapes;
                result.Propriety.Photoplace = photoPlace;

                context.SaveChanges();
            }
        }
    }
}
