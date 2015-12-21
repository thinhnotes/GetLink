using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayhaytvVn
{
    class Program
    {
        static void Main(string[] args)
        {
            var hayhaytvVnClient = new HayhaytvVnClient();
            var keyUrl = hayhaytvVnClient.GetLink("http://www.hayhaytv.vn/xem-phim/phim-bubble-gum-chuyen-tinh-bong-bong-Tap-16-hd-2338303234336E61.html");
        }
    }
}
