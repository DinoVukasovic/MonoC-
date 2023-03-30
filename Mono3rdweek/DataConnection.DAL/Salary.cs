namespace DataConnection.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Salary")]
    public partial class Salary
    {
        [Key]
        public Guid DoctorId { get; set; }

        public int SalaryAmount { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
