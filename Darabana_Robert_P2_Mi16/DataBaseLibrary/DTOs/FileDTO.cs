using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLibrary.DTOs
{
    [DataContract(IsReference = true)]
    public class FileDTO
    {
        public FileDTO(int id, string fullPath, string isPhoto)
        {
            Id = id;
            FullPath = fullPath;
            Type = isPhoto;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FullPath { get; set; }
        [DataMember]
        public string Type { get; set; }


    }
}
