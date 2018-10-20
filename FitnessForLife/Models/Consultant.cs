namespace FitnessForLife.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Consultant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Consultant()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Consultant Name is required")]
        [Column("Full Name")]
        [StringLength(150)]
        public string Full_Name { get; set; }

        [Column("Date of birth", TypeName = "date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of birth is required")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_birth { get; set; }

        [Required]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email{ get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
