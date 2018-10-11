namespace FitnessForLife.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Consultant")]
    public partial class Consultant
    {
        public int Id { get; set; }

        [Column("Full Name")]
        public string Full_Name { get; set; }

        public int? Branch { get; set; }

        public virtual Branch Branch1 { get; set; }
    }
}
