using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceReferencePhotos;
using RazorPagesPhotos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesPhotos.Pages.Photos
{
    public class IndexModel : PageModel
    {
        InterfaceServiceClient client = new InterfaceServiceClient();
        public List<Models.FileDTO> Files { get; set; }

        public SelectList Props { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Prop { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList DynamicProps{ get; set; }

        [BindProperty(SupportsGet = true)]
        public string DynamicProp { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchStringDy { get; set; }

        public IndexModel()
        {
            Files = new List<Models.FileDTO>();
        }

        public async Task OnGetAsync()
        {
            var files = await client.GetFilesAsync();

            Props = new SelectList(new[] { "Event", "People", "Landscapes", "PhotoPlace" });

            foreach (var item in files)
            {
                Models.FileDTO dto = new Models.FileDTO();

                dto.Id = item.Id;
                dto.FullPath = item.FullPath;
                dto.Type = item.Type;

                Propriety prop = new Propriety();

                prop = await client.returnProprietyAsync(item.FullPath);

                dto.Propriety = prop;

                Files.Add(dto);
            }

            ViewData["number"] = Files.Count();

            if (!string.IsNullOrEmpty(Prop) && !string.IsNullOrEmpty(SearchString))
            {
                Files.Clear();
                if (Prop.Equals("Event"))
                {
                    List<File> filesList = new List<File>();
                    filesList = await client.searchByEventAsync(SearchString);

                    foreach (var item in filesList)
                    {
                        Models.FileDTO dto = new Models.FileDTO();
                        dto.Id = item.Id;
                        if (item.IsPhoto == true)
                            dto.Type = "Poza";
                        else
                            dto.Type = "Video";
                        dto.FullPath = item.FullPath;
                        Files.Add(dto);
                    }
                }

                if (Prop.Equals("People"))
                {
                    List<File> filesList = new List<File>();
                    filesList = await client.searchByPeopleAsync(SearchString);

                    foreach (var item in filesList)
                    {
                        Models.FileDTO dto = new Models.FileDTO();
                        dto.Id = item.Id;
                        if (item.IsPhoto == true)
                            dto.Type = "Poza";
                        else
                            dto.Type = "Video";
                        dto.FullPath = item.FullPath;
                        Files.Add(dto);
                    }
                }

                if (Prop.Equals("Landscapes"))
                {
                    List<File> filesList = new List<File>();
                    filesList = await client.searchByLandscapesAsync(SearchString);

                    foreach (var item in filesList)
                    {
                        Models.FileDTO dto = new Models.FileDTO();
                        dto.Id = item.Id;
                        if (item.IsPhoto == true)
                            dto.Type = "Poza";
                        else
                            dto.Type = "Video";
                        dto.FullPath = item.FullPath;
                        Files.Add(dto);
                    }
                }

                if (Prop.Equals("PhotoPlace"))
                {
                    List<File> filesList = new List<File>();
                    filesList = await client.searchByPhotoPlaceAsync(SearchString);

                    foreach (var item in filesList)
                    {
                        Models.FileDTO dto = new Models.FileDTO();
                        dto.Id = item.Id;
                        if (item.IsPhoto == true)
                            dto.Type = "Poza";
                        else
                            dto.Type = "Video";
                        dto.FullPath = item.FullPath;
                        Files.Add(dto);
                    }
                }

                ViewData["Number"] = Files.Count();
            }

            List<DynamicPropriety> listDyProps = await client.allDynamicPropsAsync();
            List<string> propsName = new List<string>();

            foreach(DynamicPropriety prop in listDyProps)
                propsName.Add(prop.ProprietyName);

            DynamicProps = new SelectList(propsName.Distinct());

            if (!string.IsNullOrEmpty(DynamicProp) && string.IsNullOrEmpty(SearchStringDy))
            {
                Files.Clear();
                List<File> filesList = new List<File>();
                filesList = await client.searchByDynamicPropNameAsync(DynamicProp);

                foreach (var item in filesList)
                {
                    Models.FileDTO dto = new Models.FileDTO();
                    dto.Id = item.Id;
                    if (item.IsPhoto == true)
                        dto.Type = "Poza";
                    else
                        dto.Type = "Video";
                    dto.FullPath = item.FullPath;
                    Files.Add(dto);
                }

                ViewData["Number"] = Files.Count();
            }
            else if(!string.IsNullOrEmpty(DynamicProp) && !string.IsNullOrEmpty(SearchStringDy))
            {
                Files.Clear();
                List<File> filesList = new List<File>();
                filesList = await client.searchByDynamicPropAsync(DynamicProp,SearchStringDy);

                foreach (var item in filesList)
                {
                    Models.FileDTO dto = new Models.FileDTO();
                    dto.Id = item.Id;
                    if (item.IsPhoto == true)
                        dto.Type = "Poza";
                    else
                        dto.Type = "Video";
                    dto.FullPath = item.FullPath;
                    Files.Add(dto);
                }

                ViewData["Number"] = Files.Count();
            }
        }
    }
}