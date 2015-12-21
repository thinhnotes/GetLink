using Core;

namespace HayhaytvVn
{
    [Site("http://www.hayhaytv.vn")]
    public class GetLinkHayhaytvVn : IGetLink
    {
        public string GetLink(string url)
        {
            var hayhaytvVnClient = new HayhaytvVnClient();
            return hayhaytvVnClient.GetLink(url);
        }
    }
}