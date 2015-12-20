using Core;

namespace GLHdOnline
{
    [Site("http://hdonline.vn")]
    public class GetLinkHdOnline : IGetLink
    {
        public string GetLink(string url)
        {
            var getLinkHdOnline = new HdOnlineClient();
            return getLinkHdOnline.GetLink(url);
        }
    }
}