using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace Test.Extensibility
{
    /// <summary>
    /// Custom attribute for exporting a plugin
    /// 
    /// Enables us to give customers specific attributes to use, rather than relying on them knowing anything about MEF
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportPluginAttribute : ExportAttribute
    {
        public ExportPluginAttribute(string name)
            : base(typeof(IPlugin))
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
