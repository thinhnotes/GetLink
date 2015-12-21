using System.Configuration;

namespace HayhaytvVn
{
    public static class ConfigVariable
    {
        public static string Host => ConfigurationManager.AppSettings["Host"] ?? "http://www.hayhaytv.vn/";
        public static string PatternKeyUrl => ConfigurationManager.AppSettings["PatternKeyUrl"] ?? "adsXMLURL= \"(?<key>[\\w://.-]+)\"";
        public static string PatternKeyElement => ConfigurationManager.AppSettings["PathConfigFileElement"] ?? "links";

        public static int Element
        {
            get
            {
                int outint;
                return int.TryParse(ConfigurationManager.AppSettings["PathConfigFileElement"], out outint) ? outint : 0;
            }
        }

        public static string KeyElement => ConfigurationManager.AppSettings["KeyElement"] ?? "file:'(?<key>[\\w:/.]+)'";
    }
}