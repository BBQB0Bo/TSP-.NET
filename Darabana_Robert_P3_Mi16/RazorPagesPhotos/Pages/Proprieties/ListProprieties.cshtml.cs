using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPhotos.Models;
using ServiceReferencePhotos;

namespace RazorPagesPhotos.Pages.Proprieties
{
    public class ListProprietiesModel : PageModel
    {

        InterfaceServiceClient client = new InterfaceServiceClient();
        public ProprietyDTO Propriety { get; set; }
        public List<DynamicProprietyDTO> DynamicProps {get;set;}

        public ListProprietiesModel()
        {
            Propriety = new ProprietyDTO();
            DynamicProps = new List<DynamicProprietyDTO>();
        }
        public async Task OnGetAsync(int? id,string path)
        {
            if (path == null)
                return;
            var prop = await client.returnProprietyAsync(path);
            ViewData["Photo"] = id.ToString() ;

            Propriety.Id = prop.Id;
            Propriety.Landscapes = prop.Landscapes;
            Propriety.People = prop.People;
            Propriety.Photoplace = prop.Photoplace;
            Propriety.Event = prop.Event;
            Propriety.DataCreated = prop.DataCreated;

            List<DynamicPropriety> listDynamicProps = await client.returnDynamicPropsAsync(path);

            foreach(DynamicPropriety p in listDynamicProps)
            {
                DynamicProprietyDTO dto = new DynamicProprietyDTO();
                dto.Id = p.Id;
                dto.ProprietyName = p.ProprietyName;
                dto.ProprietyValue = p.ProprietyValue;

                DynamicProps.Add(dto);
            }

        }
    }
}