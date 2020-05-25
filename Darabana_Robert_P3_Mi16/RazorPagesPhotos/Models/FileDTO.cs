using ServiceReferencePhotos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesPhotos.Models
{
    public class FileDTO
    {
        public int Id { get; set; }

        public string FullPath { get; set; }

        public string Type { get; set; }

        public Propriety Propriety { get; set; } = new Propriety();

        public List<DynamicPropriety> DynamicProprieties { get; set; } = new List<DynamicPropriety>();
    }
}
