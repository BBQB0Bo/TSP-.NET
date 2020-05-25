using ServiceReferencePhotos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesPhotos.Models
{
    public class DynamicProprietyDTO
    {
        public int Id { get; set; }

        public string ProprietyName { get; set; }

        public string ProprietyValue { get; set; }

        public List<File> Files { get; set; } = new List<File>();
    }
}
