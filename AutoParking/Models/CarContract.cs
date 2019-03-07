using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models
{
    public class CarContract
    {
        public string ID { get; set; }

        public System.DateTime TimeStart { get; set; }

        public Nullable<System.DateTime> TimeEnd { get; set; }

        public string Digit { get; set; }

        public string IDIn { get; set; }

        public string IDOut { get; set; }

        public Nullable<int> CostIn { get; set; }

        public Nullable<int> Cost { get; set; }

        public string Part { get; set; }

        public Nullable<int> Seri { get; set; }

        public string IDTicketMonth { get; set; }

        public string IDPart { get; set; }

        public string Images { get; set; }

        public string Images2 { get; set; }

        public string Images3 { get; set; }

        public string Images4 { get; set; }

        public Nullable<int> MatThe { get; set; }

        public string Computer { get; set; }

        public string Note { get; set; }

        public string Account { get; set; }

        public Nullable<int> CostBefore { get; set; }

        public Nullable<System.DateTime> DateUpdate { get; set; }

        string Authority = HttpContext.Current.Request.Url.Authority;   // ==> localhost:1478
        public string ImagesURL1
        {
            set { }
            get
            {
                string ApplicationPath = HttpContext.Current.Request.ApplicationPath;  // ==> /
                if (ApplicationPath.Length > 1) ApplicationPath += "/";
                string url = string.Format("http://{0}{1}Images/XeVao/{2}/{3}", Authority, ApplicationPath, TimeStart.ToString("yyyy-MM-dd"), Images + ".jpg");
                return url;
            }
        }
        public string ImagesURL2
        {
            set { }
            get
            {

                string ApplicationPath = HttpContext.Current.Request.ApplicationPath;  // ==> /
                if (ApplicationPath.Length > 1) ApplicationPath += "/";
                string url = string.Format("http://{0}{1}Images/XeVao/{2}/{3}", Authority, ApplicationPath, TimeStart.ToString("yyyy-MM-dd"), Images2 + ".jpg");
                return url;
            }
        }
        public string ImagesURL3
        {
            set { }
            get
            {
                if (Images3 != "")
                {
                    string ApplicationPath = HttpContext.Current.Request.ApplicationPath;  // ==> /
                    if (ApplicationPath.Length > 1) ApplicationPath += "/";
                    string url = string.Format("http://{0}{1}Images/XeRa/{2}/{3}", Authority, ApplicationPath, TimeStart.ToString("yyyy-MM-dd"), Images3 + ".jpg");
                    return url;
                }
                else
                    return "";
            }
        }
        public string ImagesURL4
        {
            set { }
            get
            {
                if (Images4 != "")
                {
                    string ApplicationPath = HttpContext.Current.Request.ApplicationPath;  // ==> /
                    if (ApplicationPath.Length > 1) ApplicationPath += "/";
                    string url = string.Format("http://{0}{1}Images/XeRa/{2}/{3}", Authority, ApplicationPath, TimeStart.ToString("yyyy-MM-dd"), Images4 + ".jpg");
                    return url;
                }
                else
                    return "";
            }
        }
    }
}