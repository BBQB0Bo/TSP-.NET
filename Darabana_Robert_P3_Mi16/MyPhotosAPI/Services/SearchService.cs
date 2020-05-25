using DataBaseLibrary;
using DataBaseLibrary.DTOs;
using System;
using System.Collections.Generic;

namespace MyPhotosAPI.Services
{
    public class SearchService
    {
        public readonly MyPhotosModelContainer context;

        public SearchService()
        {
            this.context = new MyPhotosModelContainer();
        }

        /*Cautarile dupa Proprietatile standard care nu pot fi modificate(implicite din aplicatie)*/
        /*Ele sunt DateCreated,Event,People,Landscapes,PhotoPlace*/


        /*Cautare dupa data , formatul datei este AN-LUNA-ZI*/
        public List<File> searchByDate(String date)
        {
            DateTime dateTime = ProprietyService.returnDateTime(date);
            List<File> solutionList = new List<File>();

            foreach (Propriety prop in context.Proprieties.Include("File"))
            {
                if (prop.DataCreated.Equals(dateTime))
                    solutionList.Add(prop.File);
            }

            return solutionList;
        }

        /*Cautare dupa Eveniment - UNUL SINGUR!*/
        public List<File> searchByEvent(String eve)
        {
            List<File> solutionList = new List<File>();

            foreach (Propriety prop in context.Proprieties.Include("File"))
            {
                if (prop.Event.Equals(eve))
                    solutionList.Add(prop.File);
            }

            return solutionList;
        }

        /*Cautare dupa Persoane(People) , Formatul este Prenume,Prenume,Prenume etc...*/
        public List<File> searchByPeople(String people)
        {
            List<File> solutionList = new List<File>();

            foreach (Propriety prop in context.Proprieties.Include("File"))
            {
                if (prop.People.Equals(people))
                    solutionList.Add(prop.File);
            }

            return solutionList;
        }

        /*Cautare dupa Peisaje(Landscapes) , Formatul este Peisaj,Peisaj,Peisaj etc...*/
        public List<File> searchByLandscapes(String landscapes)
        {
            List<File> solutionList = new List<File>();

            foreach (Propriety prop in context.Proprieties.Include("File"))
            {
                if (prop.Landscapes.Equals(landscapes))
                    solutionList.Add(prop.File);
            }

            return solutionList;
        }

        /*Cautare dupa locul fotografiei(PhotoPlace), este doar un singur loc!*/
        public List<File> searchByPhotoPlace(String photoPlace)
        {
            List<File> solutionList = new List<File>();

            foreach (Propriety prop in context.Proprieties.Include("File"))
            {
                if (prop.Photoplace.Equals(photoPlace))
                    solutionList.Add(prop.File);
            }

            return solutionList;
        }


        /*Cautarile dupa Proprietatile dinamice adaugate de utilizator*/
        /*Cautare se face dupa nume proprietare si valoare*/

        public List<File> searchByDynamicProp(String propName, String propValue)
        {
            List<File> solutionList = new List<File>();
            foreach (DynamicPropriety prop in context.DynamicProprieties.Include("Files"))
            {
                if (prop.ProprietyName.Equals(propName) && prop.ProprietyValue.Equals(propValue))
                {
                    foreach (File file in prop.Files)
                    {
                        solutionList.Add(file);
                    }

                    break;
                }
            }

            return solutionList;
        }

        /*Cautarile dupa Proprietatile dinamice adaugate de utilizator*/
        /*Cautare doar dupa numele proprietatii nu si dupa valoarea acesteia!*/
        public List<File> searchByDynamicPropName(String propName)
        {
            List<File> solutionList = new List<File>();
            List<int> solutionIds = new List<int>();

            foreach (DynamicPropriety prop in context.DynamicProprieties.Include("Files"))
            {
                if (prop.ProprietyName.Equals(propName))
                {
                    foreach (File file in prop.Files)
                    {
                        if (!solutionIds.Contains(file.Id))
                        {
                            solutionList.Add(file);
                            solutionIds.Add(file.Id);
                        }
                    }

                }
            }

            return solutionList;
        }
    }
}
