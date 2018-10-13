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

        public string Username { get; set; }

        [Column("Date And Time")]
        public DateTime? Date_And_Time { get; set; }

        public int? Branch { get; set; }

        public int? Consultant { get; set; }

        public virtual Branch Branch1 { get; set; }

        public virtual Consultant Consultant1 { get; set; }
    }
}
