//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CommunityAssist2017MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GrantApplication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GrantApplication()
        {
            this.GrantApplicationReviews = new HashSet<GrantApplicationReview>();
        }
    
        public int GrantApplicationKey { get; set; }
        public Nullable<int> PersonKey { get; set; }
        public Nullable<System.DateTime> GrantAppicationDate { get; set; }
        public Nullable<int> GrantTypeKey { get; set; }
        public decimal GrantApplicationRequestAmount { get; set; }
        public string GrantApplicationReason { get; set; }
        public Nullable<int> GrantApplicationStatusKey { get; set; }
        public Nullable<decimal> GrantApplicationAllocationAmount { get; set; }
    
        public virtual GrantType GrantType { get; set; }
        public virtual GrantApplicationStatu GrantApplicationStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrantApplicationReview> GrantApplicationReviews { get; set; }
        public virtual Person Person { get; set; }
    }
}
