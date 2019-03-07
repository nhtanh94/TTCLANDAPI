using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RequestModel
{
    public class LogRequest
    {
        [Required]
        public string blockCode { get; set; }
        [Required]
        public DateTime fromDate { get; set; }
        [Required]
        public DateTime toDate { get; set; }
        /// <summary>
        ///Tất cả, Kích hoạt thẻ, Lưu mất thẻ, Tạo thẻ mới, Xóa thông tin thẻ, Ngưng sử dụng, Xóa thẻ tháng, Chỉnh sửa vé tháng, Kích hoạt lại thẻ tháng
        /// </summary>
        public string ActionType { get; set; }
    }
}