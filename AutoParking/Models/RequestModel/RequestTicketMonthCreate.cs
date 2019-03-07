using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RequestModel
{
    public class RequestTicketMonthCreate
    {
        [Required]
        public string blockCode { get; set; }
        /// <summary>
        /// ID tài khoản người tạo
        /// </summary>
        [Required]
        public string IdAccountCreate { get; set; }

        /// <summary>
        /// Số thứ tự
        /// </summary>
        [Required]
        public int Stt { get; set; }

        /// <summary>
        /// Mã thẻ
        /// </summary>
        [Required]
        public string ID { get; set; }

        /// <summary>
        /// Biển số
        /// </summary>
        [Required]
        public string Digit { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string TenKH { get; set; }

        /// <summary>
        /// Chứng minh nhân dân
        /// </summary>
        public string CMND { get; set; }

        /// <summary>
        /// Công ty
        /// </summary>
        public string Company { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Hiệu xe
        /// </summary>
        public string CarKind { get; set; }

        /// <summary>
        /// Id hiệu xe
        /// </summary>
        [Required]
        public string IDPart { get; set; }

        /// <summary>
        /// Ngày đăng ký. Ví dụ: 2018-11-24 00:00:00
        /// </summary>
        [Required]
        public DateTime fromDate { get; set; }

        /// <summary>
        /// Ngày hết hạng. Ví dụ: 2018-12-24 23:59:00
        /// </summary>
        [Required]
        public DateTime toDate { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Số tiền
        /// </summary>
        [Required]
        public int Amount { get; set; }
    }
}