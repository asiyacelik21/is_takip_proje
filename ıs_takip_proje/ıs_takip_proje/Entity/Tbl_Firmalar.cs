//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ıs_takip_proje.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Firmalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Firmalar()
        {
            this.Tbl_Cagrilar = new HashSet<Tbl_Cagrilar>();
        }
    
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Yetkili { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Sektor { get; set; }
        public string İl { get; set; }
        public string İlce { get; set; }
        public string Adres { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Cagrilar> Tbl_Cagrilar { get; set; }
    }
}
