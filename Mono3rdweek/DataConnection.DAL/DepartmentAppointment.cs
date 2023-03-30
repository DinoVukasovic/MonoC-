namespace DataConnection.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentAppointment")]
    public partial class DepartmentAppointment
    {
        public Guid DepartmentId { get; set; }

        public Guid AppointmentId { get; set; }

        public Guid Id { get; set; }

        public virtual Appointment Appointment { get; set; }

        public virtual Department Department { get; set; }
    }
}
