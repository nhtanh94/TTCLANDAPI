using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Utils
{
    public class Constants
    {
        public static bool IS_DEBUG = true;

        //ERROR_CODE
        public static int ERROR_CODE_SUCCESS = 0;
        public static int ERROR_CODE_FAIL = 1;

        //Response messages
        public static string SUCCESS = "SUCCESS";
        public static string FAILD = "FAILD";
        public static string BODY_NOT_FOUND = "BODY_NOT_FOUND";
        public static string NOT_FOUND = "NOT_FOUND";

        //Response messages
        public static string MSG_USED = "Đang sử dụng";
        public static string MSG_BLOCK = "Đã khóa";
        public static string MSG_TICKET_MONTH_NOT_CREATE = "Chưa tạo thẻ tháng";
        public static string MSG_TICKET_MONTH_CREATED = "Đã tạo thẻ tháng";
        public static string MSG_ERROR_MAXIMUM_DATE_30 = "Dữ liệu vượt quá 30 ngày";
        public static string MSG_ERROR_MAXIMUM_DATE_7 = "Dữ liệu vượt quá 7 ngày";
        public static string MSG_ERROR_DATE = "Thời gian bắt đầu lớn hơn thời gian kết thúc";
        public static string MSG_ERROR_WRONG_PARAMETER = "Sai tham số";
        public static string MSG_ERROR_WRONG_PARAMETER_AND_TYPE = "Vui lòng kiểm tra tham số và kiểu dữ liệu";
        public static string MSG_ERROR_ID_USER_CAR = "Id account không tồn tại";
        public static string MSG_ERROR_ID_PART = "Id part không tồn tại";
        public static string MSG_ERROR_ROW_ID = "RowID không tồn tại";
        public static string MSG_ERROR_LOGIN = "Tài khoản hoặc mật khẩu không đúng";
        public static string CODEERROR = "Mã tòa nhà không đúng";
        public static string ACCOUNT = "Admin";
        public static string MSG_NO_CARD = "Thẻ không tồn tại";
        public static string MSG_BLOCK_1 = "Thẻ vãng lai đã được đưa vào danh sách đen !";

    }
}