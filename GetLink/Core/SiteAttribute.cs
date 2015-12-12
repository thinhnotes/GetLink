using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Set SiteName for dynamic of plugin
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SiteAttribute : Attribute
    {
        public string SiteName { get; set; }
        public string Version { get; set; }

        public SiteAttribute(string siteName)
        {
            SiteName = siteName;
            Version = "1.0";
        }
    }
}
