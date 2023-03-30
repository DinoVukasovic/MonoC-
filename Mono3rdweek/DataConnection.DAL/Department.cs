namespace DataConnection.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Department")]
    public partial class Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            DepartmentAppointments = new HashSet<DepartmentAppointment>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public Guid HospitalId { get; set; }

        public Guid DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Hospital Hospital { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentAppointment> DepartmentAppointments { get; set; }
    }
}
