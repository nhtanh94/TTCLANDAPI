namespace AutoParking.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(150)]
        public string LoaiThaoTac { get; set; }

        [StringLength(500)]
        public string ThongTin { get; set; }

        [StringLength(50)]
        public string NguoiXuLy { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime NgayXuly { get; set; }

        [StringLength(50)]
        public string May { get; set; }
    }
}
