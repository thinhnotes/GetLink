using Core;

namespace GLHdOnline
{
    [Site("http://hdonline.vn")]
    public class GetLinkHdOnline : IGetLink
    {
        public string GetLink(string url)
        {
            return url;
        }
    }
}