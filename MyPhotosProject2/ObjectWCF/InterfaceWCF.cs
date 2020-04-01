using DataBaseLibrary;
using DataBaseLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ObjectWCF
{
    [ServiceContract]
    interface InterfaceFileService
    {
        [OperationContract]
        void PrintFiles(List<DataBaseLibrary.File> listFile);

        [OperationContract]
        List<DataBaseLibrary.File> GetPhotos();

        [OperationContract]
        List<DataBaseLibrary.File> GetVideos();

        [OperationContract]
        List<FileDTO> GetFiles();

        [OperationContract]
        int GetMaxId();

        [OperationContract]
        string AddFile(string fullPath, string dataCreated, string eve, string people, string landscapes, string photoPlace);

        [OperationContract]
        string[] AddFilesFromDirectory(string fullPath);

        [OperationContract]
        bool PhotoOrImage(string fullPath);

        [OperationContract]
        string DeleteFile(string fullPath);
    }

    [ServiceContract]
    interface InterfaceProprietyService
    {
        [OperationContract]
        Propriety returnPropriety(string fullPath);

        [OperationContract]
        DateTime returnDateTime(string date);

        [OperationContract]
        void updateDateTime(string fullPath, string date);

        [OperationContract]
        void updateEvent(string fullPath, string eve);

        [OperationContract]
        void updatePeople(string fullPath, string people);

        [OperationContract]
        void updateLandscapes(string fullPath, string landscapes);

        [OperationContract]
        void updatePhotoPlace(string fullPath, string photoPlace);

        [OperationContract]
        void updateAll(string fullPath, string date, string eve, string people, string landscapes, string photoPlace);
    }

    [ServiceContract]
    interface InterfaceSearchService
    {
        [OperationContract]
        List<File> searchByDate(String date);

        [OperationContract]
        List<File> searchByEvent(String eve);

        [OperationContract]
        List<File> searchByPeople(String people);

        [OperationContract]
        List<File> searchByLandscapes(String landscapes);

        [OperationContract]
        List<File> searchByPhotoPlace(String photoPlace);

        [OperationContract]
        List<File> searchByDynamicProp(String propName, String propValue);

        [OperationContract]
        List<File> searchByDynamicPropName(String propName);
    }

    [ServiceContract]
    interface InterfaceDynamicPropService
    {
        [OperationContract]
        int GetMaxId();

        [OperationContract]
        void AddDynamicProp(string fullPath, string proprietyName, string proprietyValue);

        [OperationContract]
        void DeleteDynamicProp(string fullPath, string propName);

        [OperationContract]
        void UpdateDynamicProp(string fullPath, string propName, string oldPropValue, string newPropValue);
    }

    [ServiceContract]
    interface InterfaceService:InterfaceFileService,InterfaceProprietyService,InterfaceSearchService,InterfaceDynamicPropService
    {

    }
}
