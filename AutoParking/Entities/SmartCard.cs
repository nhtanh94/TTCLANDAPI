namespace AutoParking.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SmartCard")]
    public partial class SmartCard
    {
        public int Identify { get; set; }

        [StringLength(50)]
        public string ID { get; set; }

        public bool Using { get; set; }

        public int? Type { get; set; }

        public DateTime? DayUnlimit { get; set; }
    }
}
