namespace AutoParking.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
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
        public string Digit { get; set; }

        [StringLength(50)]
        public string IDIn { get; set; }

        [StringLength(50)]
        public string IDOut { get; set; }

        public int? CostIn { get; set; }

        public int? Cost { get; set; }

        [StringLength(50)]
        public string Part { get; set; }

        public int? Seri { get; set; }

        [StringLength(50)]
        public string IDTicketMonth { get; set; }

        [StringLength(50)]
        public string IDPart { get; set; }

        [StringLength(150)]
        public string Images { get; set; }

        [StringLength(150)]
        public string Images2 { get; set; }

        [StringLength(150)]
        public string Images3 { get; set; }

        [StringLength(150)]
        public string Images4 { get; set; }

        public int? MatThe { get; set; }

        [StringLength(50)]
        public string Computer { get; set; }

        [StringLength(350)]
        public string Note { get; set; }

        [StringLength(50)]
        public string Account { get; set; }

        public int? CostBefore { get; set; }

        public DateTime? DateUpdate { get; set; }
    }
}
