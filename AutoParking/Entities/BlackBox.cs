namespace AutoParking.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BlackBox")]
    public partial class BlackBox
    {
        [Key]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Path { get; set; }
    }
}
