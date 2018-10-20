namespace FitnessForLife.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Appointments = new HashSet<Appointment>();
        }

        public string Id { get; set; }

        [Column("First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100)]
        public string First_Name { get; set; }

        [Column("Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(100)]
        public string Last_Name { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
