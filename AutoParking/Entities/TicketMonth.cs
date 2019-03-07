namespace AutoParking.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TicketMonth")]
    public partial class TicketMonth
    {
        public int RowID { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Stt { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ID { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime ProcessDate { get; set; }

        [StringLength(50)]
        public string Digit { get; set; }

        [StringLength(200)]
        public string TenKH { get; set; }

        [StringLength(50)]
        public string CMND { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string CarKind { get; set; }

        [StringLength(50)]
        public string IDPart { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        [StringLength(400)]
        public string Note { get; set; }

        [StringLength(50)]
        public string Amount { get; set; }

        [StringLength(50)]
        public string ChargesAmount { get; set; }

        public int? Status { get; set; }

        [StringLength(50)]
        public string Account { get; set; }

        [StringLength(50)]
        public string Images { get; set; }

        public DateTime? DayUnLimit { get; set; }
    }
}
