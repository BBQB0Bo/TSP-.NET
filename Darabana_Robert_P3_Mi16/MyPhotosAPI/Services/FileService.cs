using DataBaseLibrary;
using DataBaseLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotosAPI.Services
{
    public class FileService
    {
        public readonly MyPhotosModelContainer context;

        public FileService()
        {
            this.context = new MyPhotosModelContainer();
        }

        /*Afiseaza Files la consola , ca sa ne ajute pentru testare*/
        public void PrintFiles(List<DataBaseLibrary.File> listFile)
        {
            foreach (DataBaseLibrary.File file in listFile)
            {
                Console.WriteLine(file.Id + " " + file.FullPath + " " + file.IsPhoto + " " + file.IsDeleted);
            }
        }

        /*Functie care returneaza o lista doar cu pozele*/
        public List<DataBaseLibrary.File> GetPhotos()
        {
            var photos = context.Files.Where(a => a.IsPhoto == true);

            return photos.ToList();
        }

        /*Functie care returneaza o lista doar cu video-urile*/
        public List<DataBaseLibrary.File> GetVideos()
        {
            var videos = context.Files.Where(a => a.IsPhoto == false);

            return videos.ToList();
        }

        /*Functie care returneaza o lista cu toate Fileluri-le*/
        public List<FileDTO> GetFiles()
        {
            List<FileDTO> filesDTO = new List<FileDTO>();
            List<DataBaseLibrary.File> files = context.Files.ToList();
            foreach (DataBaseLibrary.File file in files)
            {
                string photo = "";
                if (file.IsPhoto == true)
                    photo = "Poza";
                else photo = "Video";
                FileDTO fileDTO = new FileDTO(file.Id, file.FullPath, photo);
                filesDTO.Add(fileDTO);
            }
            return filesDTO;
        }

        /*Functie prin care aflam id-ul maxim din tabela File*/
        public int GetMaxId()
        {
            var maxId = 0;
            if (context.Files.Count() == 0)
                maxId = 0;
            else
                maxId = context.Files.Max(a => a.Id); //Aflam id-ul maxim curent din tabelul File , ca sa il folosim ulterior.

            return maxId;
        }

        /*Functie care adauga o poza/video in tabelul File alaturi de proprietatile ei*/
        public string AddFile(string fullPath, string dataCreated, string eve, string people, string landscapes, string photoPlace)
        {
            /*Verificam daca fullPath este un Folder sau un File*/
            if (System.IO.File.Exists(Path.GetFullPath(fullPath)))
            {
                //Este poza sau video , o adaugam in baza de date corespunzator
                bool value = PhotoOrImage(fullPath);
                //maxId - il marim cu unu - id urmator , fullPath-ul , este poza sau video , setam implicit - false(nu a fost schimbat 
                // path-ul)
                int maxId = GetMaxId();

                Propriety propriety = new Propriety(maxId + 1, ProprietyService.returnDateTime(dataCreated), eve, people, landscapes, photoPlace);

                bool isDeleted = false;

                DataBaseLibrary.File file = new DataBaseLibrary.File(maxId + 1, Path.GetFullPath(fullPath), value, isDeleted, propriety);
                context.Files.Add(file);
                context.SaveChanges();
                return "Fisierul a fost adaugat cu succes.";
            }
            else return "Fisierul este director sau altceva necunoscut";
        }

        /*Functie prin care parcurgem un director si afisam ulterior fullpathuile pozelor ca sa putem apela functia AddFile*/
        public string[] AddFilesFromDirectory(string fullPath)
        {
            if (Directory.Exists(Path.GetFullPath(fullPath)))
            {
                //Daca este director parcurgem toate fisierele din el si le adaugam pe rand in baza de date 
                //in functie de ce este , poza sau video
                string[] files = Directory.GetFiles(Path.GetFullPath(fullPath));
                return files;
            }
            return null;
        }


        /*Functie prin care verificam daca la path-ul dat se afla o poza sau un video*/
        public bool PhotoOrImage(string fullPath)
        {
            List<string> photoExtensions = new List<string>()
                {
                    ".jpg",
                    ".jpeg",
                    ".jpe",
                    ".png",
                    ".jp2",
                    ".j2k"
                };
            List<string> videoExtensions = new List<string>()
                {
                    ".avchd",
                    ".avi",
                    ".flv",
                    ".mkv",
                    ".mov",
                    ".mp4"
                };
            //Este fisier .. aflam extensia si adaugam in baza de date cu parametrul IsPhoto = 1 -> poza IsPhoto = 0 -> video
            string getExtension = Path.GetExtension(Path.GetFullPath(fullPath)).ToLower();

            if (photoExtensions.Contains(getExtension))
                return true; // 1 - este poza
            else if (videoExtensions.Contains(getExtension))
                return false; // 0 - este video
            else return true; // Nu cunoastem formatul , returnam implicit true !!
        }

        /*Functie prin care stergem un anumit file dat de utilizator
        De asemenea aceasta functie o sterge din ambele tabele File - Propriety
        Aplicatia Sterge si legaturile dintre Files si Dynmaic - Propriety 
        Daca sunt doua cu acelasi full_path o sterge pe prima*/
        public string DeleteFile(string fullPath)
        {
            DataBaseLibrary.File file = context.Files.FirstOrDefault(a => a.FullPath.Equals(fullPath));
            if (file == null)
                return "Nu s-a putut";
            else
            {
                file.DynamicProprieties.Clear();

                DataBaseLibrary.Propriety propriety = context.Proprieties.FirstOrDefault(a => a.Id == file.Id);
                context.Proprieties.Remove(propriety);
                context.Files.Remove(file);
                context.SaveChanges();
                return "Succes";
            }
        }
    }
}
