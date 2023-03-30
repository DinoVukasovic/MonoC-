using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataConnection.DAL
{
    public partial class HospitalContext : DbContext
    {
        public HospitalContext()
            : base("name=HospitalContext")
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentAppointment> DepartmentAppointments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasMany(e => e.DepartmentAppointments)
                .WithRequired(e => e.Appointment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Hospitals)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Patients)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.DepartmentAppointments)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Specialization)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .HasOptional(e => e.Salary)
                .WithRequired(e => e.Doctor);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Hospital>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.Hospital)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Illnness)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);
        }
    }
}
