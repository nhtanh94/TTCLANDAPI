using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models
{
    public static class ActionType
    {
        public static string ALL = "Tất cả";
        public static string ACTIVE_CARD = "Kích hoạt thẻ";
        public static string SAVE_LOST_CARD = "Lưu mất thẻ";
        public static string CREATE_CARD = "Tạo thẻ mới";
        public static string DELETE_CARD_INFO = "Xóa thông tin thẻ";
        public static string STOP_USING_TICKET_MONTH_CARD = "Ngưng sử dụng thẻ tháng";
        public static string UNBLOCK_TICKET_MONTH_CARD = "Kích hoạt lại thẻ tháng";
        public static string DELETE_TICKET_MONTH_CARD = "Xóa thẻ tháng";
        public static string EDIT_TICKET_MONTH_CARD = "Chỉnh sửa thẻ tháng";
        public static string CREATE_TICKET_MONTH_CARD = "Tạo thẻ tháng";
        public static string UPDATE_LOST_TICKET_MONTH_CARD = "Cập nhật mất thẻ tháng";
        public static string RENEWAL_TICKET_MONTH_CARD = "Gia hạn thẻ tháng";
        public static string DELETE_BLACK_CARD = "Khôi phục lại thẻ chip";
    }
}