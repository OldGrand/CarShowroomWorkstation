//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarShowroomWorkstation
{
    using System;
    using System.Collections.Generic;
    
    public partial class Managers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Managers()
        {
            this.Orders = new HashSet<Orders>();
        }
    
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte WorkExperience { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public int AdministratorFK { get; set; }
        public byte IsWorking { get; set; }
        public int ID_manager { get; set; }
    
        public virtual Administrators Administrators { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
