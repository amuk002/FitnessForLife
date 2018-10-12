namespace FitnessForLife.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Appointment
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string UserName { get; set; }

        public DateTime? DateAndTime { get; set; }

        public int? Branch { get; set; }

        public int? Consultant { get; set; }

        public virtual Branch Branch1 { get; set; }

        public virtual Consultant Consultant1 { get; set; }
    }
}
