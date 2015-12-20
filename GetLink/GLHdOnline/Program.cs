using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLHdOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            var hdOnlineClient = new HdOnlineClient();
            var keyUrl = hdOnlineClient.GetLink("http://hdonline.vn/phim-youth-tuoi-thanh-xuan-10645.html");
        }
    }
}
