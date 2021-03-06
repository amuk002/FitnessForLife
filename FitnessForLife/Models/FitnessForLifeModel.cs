namespace FitnessForLife.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FitnessForLifeModel : DbContext
    {
        public FitnessForLifeModel()
            : base("name=FitnessForLifeModel")
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Consultant> Consultants { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Appointments)
                .WithOptional(e => e.Branch1)
                .HasForeignKey(e => e.Branch);

            modelBuilder.Entity<Consultant>()
                .HasMany(e => e.Appointments)
                .WithOptional(e => e.Consultant1)
                .HasForeignKey(e => e.Consultant);
        }
    }
}
