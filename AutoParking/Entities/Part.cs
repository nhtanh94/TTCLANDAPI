namespace AutoParking.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Part")]
    public partial class Part
    {
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? Amount { get; set; }

        [StringLength(2)]
        public string Sign { get; set; }

        public int? Limit { get; set; }
    }
}
