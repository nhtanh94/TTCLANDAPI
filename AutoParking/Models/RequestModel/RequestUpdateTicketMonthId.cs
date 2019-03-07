using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RequestModel
{

    public class RequestUpdateTicketMonthId
    {
        [Required]
        public string blockCode { get; set; }
        [Required]
        public int RowID { get; set; }

        /// <summary>
        /// Mã thẻ mới
        /// </summary>
        [Required]
        public string NewID { get; set; }

        /// <summary>
        /// Số thứ tự
        /// </summary>
        [Required]
        public int Stt { get; set; }


        /// <summary>
        /// ID người cập nhật
        /// </summary>
        [Required]
        public string AccountID { get; set; }
    }
}