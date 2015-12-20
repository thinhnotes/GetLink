using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Core;
using THttpWebRequest;

namespace GLHdOnline
{
    public class HdOnlineClient : TWebRequest
    {
        public string GetLink(string url)
        {
            return GetFileUrl(GetKeyUrl(url));
        }

        private string GetKeyUrl(string url)
        {
            var regex = new Regex(ConfigVariable.PatternKeyUrl);
            var match = regex.Match(url);
            if (match == null && match.Groups["key"] == null)
                throw new GetLinkException("The url not valid!");
            return match.Groups["key"].Value;
        }

        private string GetFileUrl(string key)
        {
            Uri baseUri = new Uri(ConfigVariable.Host);
            Uri myUri = new Uri(baseUri, string.Format(ConfigVariable.PathConfigFile, key));
            var content = Get(myUri.AbsoluteUri);
            XDocument doc = XDocument.Parse(content);
            var xElement = doc.Descendants().FirstOrDefault(x=>x.Name.LocalName== ConfigVariable.PatternKeyElement);
            if(xElement==null)
                throw new GetLinkException("Can not find the raw url");
            return DecodeUrl(xElement.Value);
        }

        private string DecodeUrl(string rawUrl)
        {
            var local2 = "";
            List<char> local3 = "1234567890qwertyuiopasdfghjklzxcvbnm".ToList();
            var local4 = local3.Count;
            var strlen = rawUrl.Length;
            List<char> local5 = "f909e34e4b4a76f4a8b1eac696bd63c4".ToList();
            List<char> local6 = rawUrl.Substring(local4 * 2 + 32, strlen - (local4 * 2 + 32)).ToList();
            List<char> local7 = rawUrl.Substring(0, local4 * 2).ToList();
            List<char> local8 = new List<char>();
            int local10 = 0;

            while (local10 < (local4 * 2))
            {
                var local11 = local3.IndexOf(local7[local10]) * local4;
                local11 = (local11 + local3.IndexOf(local7[(local10 + 1)]));
                var idx = (int)(Math.Floor(d: (decimal)(local10 / 2)) % local5.Count);
                local11 = local11 - local5[idx];
                local8.Add((char)(local11));
                local10 = (local10 + 2);
            }
            local10 = 0;
            while (local10 < local6.Count)
            {
                var local11 = (local3.IndexOf(local6[local10]) * local4);
                local11 = (local11 + local3.IndexOf(local6[(local10 + 1)]));
                var idx = (int)((Math.Floor(d: (decimal)(local10 / 2)) % local4));
                local11 = (local11 - local8[idx]);
                local2 = (local2 + (char)local11);
                local10 = (local10 + 2);
            }
            return local2;
        }
    }
}