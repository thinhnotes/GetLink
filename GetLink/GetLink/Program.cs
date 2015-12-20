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
            string url = "http://hdonline.vn/phim-youth-tuoi-thanh-xuan-10645.html";
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
