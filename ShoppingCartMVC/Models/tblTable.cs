//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ETCoffee.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTable()
        {
            this.tblSit = new HashSet<tblSit>();
        }
    
        public int tableId { get; set; }
        public Nullable<int> numSeats { get; set; }
        public string area { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSit> tblSit { get; set; }
    }
}
