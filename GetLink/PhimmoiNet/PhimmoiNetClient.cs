using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using THttpWebRequest;

namespace PhimmoiNet
{
    public class PhimmoiNetClient : TWebRequest
    {
        public string GetLink(string url)
        {
            var rawOrigin = GetRawOrigin(url);
            var data = Get("http://www.phimmoi.net/" + rawOrigin);
            string partern = "_responseJson='(?<link>{.+\\})";
            var regex = new Regex(partern);
            var match = regex.Match(data);
            if (match == null)
                return null;
            var jsonValue = match.Groups["link"].Value;
            var video = JsonConvert.DeserializeObject<Video>(jsonValue);
            if (video == null)
                return null;
            var maxResolution = video.Medias.Max(x=>x.Resolution);
            return video.Medias.First(x => x.Resolution == maxResolution).Url;
        }

        public string GetRawOrigin(string url)
        {
            var link = Get(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(link);
            var htmlNode = htmlDocument.DocumentNode
                .Descendants()
                .FirstOrDefault(
                    x => x.Name == "script" && x.Attributes["async"] != null && x.Attributes["async"].Value == "true");
            if (htmlNode == null || htmlNode.Attributes["src"] == null)
                throw new Exception("Can not find the link");
            return htmlNode.Attributes["src"].Value;
        }
    }
}