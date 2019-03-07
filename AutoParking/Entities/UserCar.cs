namespace AutoParking.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserCar")]
    public partial class UserCar
    {
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(50)]
        public string Pass { get; set; }

        [Required]
        [StringLength(50)]
        public string NameUser { get; set; }

        public bool Sex { get; set; }

        public bool? Working { get; set; }

        [Required]
        [StringLength(50)]
        public string IDFunct { get; set; }
    }
}
