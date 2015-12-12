using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Core;

namespace GetLink
{
    public class GetLinkClient
    {
        private static List<IGetLink> _iGetLinks = null;

        public static List<IGetLink> GetLinks
        {
            get
            {
                if (null == _iGetLinks)
                    Reload();

                return _iGetLinks;
            }
        }

        private static List<Assembly> LoadPlugInAssemblies()
        {
            var path = "Plugins";
            var dInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, path));
            if (!dInfo.Exists)
                dInfo.Create();
            var files = dInfo.GetFiles("*.dll");
            var plugInAssemblyList = new List<Assembly>();
            plugInAssemblyList.AddRange(files.Select(file => Assembly.LoadFile(file.FullName)));
            return plugInAssemblyList;
        }

        public static void Reload()
        {
            if (null == _iGetLinks)
                _iGetLinks = new List<IGetLink>();
            else
                _iGetLinks.Clear();
            var plugInAssemblies = LoadPlugInAssemblies();
            var plugIns = GetPlugIns(plugInAssemblies);

            foreach (var getLink in plugIns)
            {
                _iGetLinks.Add(getLink);
            }
        }

        private static List<IGetLink> GetPlugIns(List<Assembly> assemblies)
        {
            var availableTypes = new List<Type>();

            foreach (var currentAssembly in assemblies)
                availableTypes.AddRange(currentAssembly.GetTypes());

            // get a list of objects that implement the IGetLink interface AND 
            // have the SiteAttribute
            var calculatorList = availableTypes.FindAll(delegate(Type t)
            {
                var interfaceTypes = new List<Type>(t.GetInterfaces());
                var arr = t.GetCustomAttributes(typeof (SiteAttribute), true);
                return arr.Length != 0 && interfaceTypes.Contains(typeof (IGetLink));
            });

            // convert the list of Objects to an instantiated list of IGetLink
            return calculatorList.ConvertAll(t => Activator.CreateInstance(t) as IGetLink);
        }
    }
}