//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBaseLibrary
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public partial class DynamicPropriety
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DynamicPropriety()
        {
            this.Files = new HashSet<File>();
        }

        public DynamicPropriety(int id, string proprietyName, string proprietyValue)
        {
            this.Id = id;
            this.ProprietyName = proprietyName;
            this.ProprietyValue = proprietyValue;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ProprietyName { get; set; }
        [DataMember]
        public string ProprietyValue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [DataMember]
        public virtual ICollection<File> Files { get; set; }
    }
}
