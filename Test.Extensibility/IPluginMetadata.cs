using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Extensibility
{
    /// <summary>
    /// Strongly typed metadata used when the main application enumerates the available plugins
    /// 
    /// Property names match those on ExportPluginAttribute - MEF automatically maps them
    /// </summary>
    public interface IPluginMetadata
    {
        string Name { get; }
    }
}
