namespace AutoParking.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SetCard")]
    public partial class SetCard
    {
        [Key]
        [StringLength(50)]
        public string Kind { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        public bool? isEmSaveLostTicket { get; set; }

        public bool? isSeeReport { get; set; }

        public int? numberOfDay { get; set; }

        public bool? isGetMoneyTicket { get; set; }

        public int? LostCard { get; set; }

        public int? TotalSpace { get; set; }

        public int? TicketSpace { get; set; }

        public int? TicketLimitDay { get; set; }

        [StringLength(50)]
        public string Logo { get; set; }

        public int? NightLimit { get; set; }

        [StringLength(200)]
        public string TitleReport { get; set; }
    }
}
