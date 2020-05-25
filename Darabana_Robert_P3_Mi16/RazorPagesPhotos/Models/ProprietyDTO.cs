using ServiceReferencePhotos;

namespace RazorPagesPhotos.Models
{
    public class ProprietyDTO
    {
        public int Id { get; set; }

        public System.DateTime DataCreated { get; set; }

        public string Event { get; set; }

        public string People { get; set; }

        public string Landscapes { get; set; }

        public string Photoplace { get; set; }

        public File File { get; set; } = new File();
    }
}
