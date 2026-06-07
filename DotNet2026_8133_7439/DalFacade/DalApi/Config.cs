
//namespace DalApi;
//using System.Xml.Linq;
//using System.IO;
//static class DalConfig
//{
//    internal static string s_dalName;
//    internal static Dictionary<string, string> s_dalPackages;

//    static DalConfig()
//    {
//        XElement dalConfig = XElement.Load(
//      Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "xml", "dal-config.xml")
//  ); ;// ?? throw new DalConfigException("dal-config.xml file is not found");

//        s_dalName =
//           dalConfig.Element("dal")?.Value ?? throw new DalConfigException("<dal> element is missing");
//        var packages = dalConfig.Element("dal-packages")?.Elements() ??
//  throw new DalConfigException("<dal-packages> element is missing");
//        s_dalPackages = packages.ToDictionary(p => "" + p.Name, p => p.Value);
//    }
//}
//[Serializable]
//public class DalConfigException : Exception
//{
//    public DalConfigException(string msg) : base(msg) { }
//    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
//}using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace DalApi;

using System.Xml.Linq;

static class DalConfig
{
    internal static string s_dalName;
    internal static Dictionary<string, string> s_dalPackages;

    static DalConfig()
    {
        string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "xml", "dal-config.xml");
        XElement dalConfig = XElement.Load(configPath);

        s_dalName =
           dalConfig.Element("dal")?.Value ?? throw new DalConfigException("<dal> element is missing");

        var packages = dalConfig.Element("dal-packages")?.Elements() ??
  throw new DalConfigException("<dal-packages> element is missing");
        s_dalPackages = packages.ToDictionary(p => "" + p.Name, p => p.Value);
    }
}

[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}
