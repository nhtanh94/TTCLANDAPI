namespace AutoParking.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Computer")]
    public partial class Computer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string IDPart { get; set; }

        public int Normal1 { get; set; }

        public int Normal2 { get; set; }

        public int Normal3 { get; set; }

        public int Night { get; set; }

        public int HourBegin { get; set; }

        public int HourEnd { get; set; }

        public int? HourBeginPT { get; set; }

        public int? HourEndPT { get; set; }

        public int? Normal4 { get; set; }

        public int? isAdd { get; set; }

        public int? UnitTicket { get; set; }

        public int? MoneyTicket { get; set; }

        public int GiaThuBay { get; set; }

        public int GiaCN { get; set; }
    }
}
