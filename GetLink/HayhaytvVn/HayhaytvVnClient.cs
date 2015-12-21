using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;
using Core;
using THttpWebRequest;

namespace HayhaytvVn
{
    public class HayhaytvVnClient: TWebRequest
    {
        public string GetKeyUrl(string url)
        {
            var regex = new Regex(ConfigVariable.PatternKeyUrl);
            var match = regex.Match(Get(url));
            if (match == null && match.Groups["key"] == null)
                throw new GetLinkException("The url not valid!");
            return match.Groups["key"].Value;
        }

        public string GetLink(string url)
        {
            return Decode(GetFileUrl(url));
        }

        private string GetFileUrl(string url)
        {
            var content = Get(GetKeyUrl(url));
            var xDocument = XDocument.Parse(content);
            var declarations = xDocument.Descendants(ConfigVariable.PatternKeyElement);
            var declaration = declarations.ElementAt(ConfigVariable.Element);
            if (declaration == null)
                throw new GetLinkException("The link not fond");
            return HttpUtility.UrlDecode(declaration.Value);
        }

        public string Decode(string source)
        {
            var regex = new Regex(ConfigVariable.KeyElement);
            var match = regex.Match(source);
            if (match == null && match.Groups["key"] == null)
                throw new GetLinkException("The url not valid!");
            return match.Groups["key"].Value;
        }
    }
}