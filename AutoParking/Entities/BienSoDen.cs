namespace AutoParking.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BienSoDen")]
    public partial class BienSoDen
    {
        [Key]
        public int Rowid { get; set; }

        [StringLength(50)]
        public string Digit { get; set; }
    }
}
