using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhimmoiNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var phimmoiNetClient = new PhimmoiNetClient();
            var link = phimmoiNetClient.GetLink("http://www.phimmoi.net/phim/lac-loi-o-hong-kong-3217/xem-phim.html");
        }
    }
}
