namespace AutoParking.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkAssign")]
    public partial class WorkAssign
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime TimeStart { get; set; }

        public DateTime? TimeEnd { get; set; }

        [StringLength(50)]
        public string Computer { get; set; }
    }
}
