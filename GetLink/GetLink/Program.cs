using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetLink
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var getLink in GetLinkClient.GetLinks)
            {
                var link = getLink.GetLink("tst");
                Console.WriteLine(link);
            }
        }
    }
}
