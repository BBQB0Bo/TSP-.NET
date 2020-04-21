using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLibrary;
using DataBaseLibrary.DTOs;
using MyPhotosAPI.Services;

namespace ObjectWCF
{
    public class Service : InterfaceService
    {
        void InterfaceDynamicPropService.AddDynamicProp(string fullPath, string proprietyName, string proprietyValue)
        {
            DynamicPropService service = new DynamicPropService();
            service.AddDynamicProp(fullPath, proprietyName, proprietyValue);
        }

        string InterfaceFileService.AddFile(string fullPath, string dataCreated, string eve, string people, string landscapes, string photoPlace)
        {
            FileService service = new FileService();
            String returnValue = service.AddFile(fullPath, dataCreated, eve, people, landscapes,photoPlace);
            return returnValue;
        }

        string[] InterfaceFileService.AddFilesFromDirectory(string fullPath)
        {
            FileService service = new FileService();
            string[] files = service.AddFilesFromDirectory(fullPath);

            return files;
        }

        void InterfaceDynamicPropService.DeleteDynamicProp(string fullPath, string propName)
        {
            DynamicPropService service = new DynamicPropService();
            service.DeleteDynamicProp(fullPath, propName);
        }

        string InterfaceFileService.DeleteFile(string fullPath)
        {
            FileService service = new FileService();
            string returnValue = service.DeleteFile(fullPath);

            return returnValue;
        }

        List<FileDTO> InterfaceFileService.GetFiles()
        {
            FileService service = new FileService();

            return service.GetFiles();
        }

        int InterfaceFileService.GetMaxId()
        {
            FileService service = new FileService();
            return service.GetMaxId();
        }

        int InterfaceDynamicPropService.GetMaxId2()
        {
            DynamicPropService service = new DynamicPropService();
            return service.GetMaxId();
        }

        List<File> InterfaceFileService.GetPhotos()
        {
            FileService service = new FileService();
            return service.GetPhotos();
        }

        List<File> InterfaceFileService.GetVideos()
        {
            FileService service = new FileService();
            return service.GetVideos();
        }

        bool InterfaceFileService.PhotoOrImage(string fullPath)
        {
            FileService service = new FileService();
            return service.PhotoOrImage(fullPath);
        }

        void InterfaceFileService.PrintFiles(List<File> listFile)
        {
            FileService service = new FileService();
            service.PrintFiles(listFile);
        }

        DateTime InterfaceProprietyService.returnDateTime(string date)
        {
            return ProprietyService.returnDateTime(date);
        }

        Propriety InterfaceProprietyService.returnPropriety(string fullPath)
        {
            ProprietyService service = new ProprietyService();
            return service.returnPropriety(fullPath);
        }

        List<File> InterfaceSearchService.searchByDate(string date)
        {
            SearchService service = new SearchService();
            return service.searchByDate(date);
        }

        List<File> InterfaceSearchService.searchByDynamicProp(string propName, string propValue)
        {
            SearchService service = new SearchService();
            return service.searchByDynamicProp(propName,propValue);
        }

        List<File> InterfaceSearchService.searchByDynamicPropName(string propName)
        {
            SearchService service = new SearchService();
            return service.searchByDynamicPropName(propName);
        }

        List<File> InterfaceSearchService.searchByEvent(string eve)
        {
            SearchService service = new SearchService();
            return service.searchByEvent(eve);
        }

        List<File> InterfaceSearchService.searchByLandscapes(string landscapes)
        {
            SearchService service = new SearchService();
            return service.searchByLandscapes(landscapes);
        }

        List<File> InterfaceSearchService.searchByPeople(string people)
        {
            SearchService service = new SearchService();
            return service.searchByPeople(people);
        }

        List<File> InterfaceSearchService.searchByPhotoPlace(string photoPlace)
        {
            SearchService service = new SearchService();
            return service.searchByPhotoPlace(photoPlace);
        }

        void InterfaceProprietyService.updateAll(string fullPath, string date, string eve, string people, string landscapes, string photoPlace)
        {
            ProprietyService service = new ProprietyService();
            service.updateAll(fullPath, date, eve, people, landscapes, photoPlace);

        }

        void InterfaceProprietyService.updateDateTime(string fullPath, string date)
        {
            ProprietyService service = new ProprietyService();
            service.updateDateTime(fullPath, date);
        }

        void InterfaceDynamicPropService.UpdateDynamicProp(string fullPath, string propName, string oldPropValue, string newPropValue)
        {
            DynamicPropService service = new DynamicPropService();
            service.UpdateDynamicProp(fullPath, propName, oldPropValue, newPropValue);
        }

        void InterfaceProprietyService.updateEvent(string fullPath, string eve)
        {
            ProprietyService service = new ProprietyService();
            service.updateEvent(fullPath, eve);
        }

        void InterfaceProprietyService.updateLandscapes(string fullPath, string landscapes)
        {
            ProprietyService service = new ProprietyService();
            service.updateLandscapes(fullPath, landscapes);
        }

        void InterfaceProprietyService.updatePeople(string fullPath, string people)
        {
            ProprietyService service = new ProprietyService();
            service.updatePeople(fullPath, people);
        }

        void InterfaceProprietyService.updatePhotoPlace(string fullPath, string photoPlace)
        {
            ProprietyService service = new ProprietyService();
            service.updatePhotoPlace(fullPath, photoPlace);
        }
    }
}
