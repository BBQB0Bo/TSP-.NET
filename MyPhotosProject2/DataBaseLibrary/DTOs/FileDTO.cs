using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLibrary.DTOs
{
    public class FileDTO
    {
        public FileDTO(int id, string fullPath, string isPhoto)
        {
            Id = id;
            FullPath = fullPath;
            Type = isPhoto;
        }

        public int Id { get; set; }
        public string FullPath { get; set; }

        public string Type { get; set; }


    }
}
