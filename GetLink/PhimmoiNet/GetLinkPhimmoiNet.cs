using System;
using Core;

namespace PhimmoiNet
{
    [Site("http://www.phimmoi.net")]
    public class GetLinkPhimmoiNet : IGetLink
    {
        public string GetLink(string url)
        {
            var phimmoiNetClient = new PhimmoiNetClient();
            return phimmoiNetClient.GetLink(url);
        }
    }
}