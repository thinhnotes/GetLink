using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace GetLink
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://www.hayhaytv.vn/xem-phim/phim-bubble-gum-chuyen-tinh-bong-bong-Tap-16-hd-2338303234336E61.html";
            foreach (var getLink in GetLinkClient.GetLinks)
            {
                var arr = (SiteAttribute)getLink.GetType().GetCustomAttributes(typeof(SiteAttribute), true).FirstOrDefault();
                if (new Uri(arr.SiteName).Host == new Uri(url).Host)
                {
                    var link = getLink.GetLink(url);
                    Console.WriteLine(link);
                }
            }
        }
    }
}
