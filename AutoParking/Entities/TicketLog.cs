namespace AutoParking.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TicketLog")]
    public partial class TicketLog
    {
        public int? RowID { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(150)]
        public string ProcessType { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string STT { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(18)]
        public string ID { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime DateProcess { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(150)]
        public string Digit { get; set; }

        [StringLength(250)]
        public string TenKH { get; set; }

        [StringLength(50)]
        public string CMND { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(50)]
        public string EMail { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(150)]
        public string CarKind { get; set; }

        [StringLength(150)]
        public string IDPart { get; set; }

        [StringLength(50)]
        public string DateStart { get; set; }

        [StringLength(50)]
        public string DateEnd { get; set; }

        [StringLength(150)]
        public string Note { get; set; }

        [StringLength(150)]
        public string Amount { get; set; }

        [StringLength(150)]
        public string ChargesAmount { get; set; }

        [StringLength(50)]
        public string Account { get; set; }

        [StringLength(50)]
        public string Images { get; set; }

        [StringLength(250)]
        public string DayUnLimit { get; set; }
    }
}
