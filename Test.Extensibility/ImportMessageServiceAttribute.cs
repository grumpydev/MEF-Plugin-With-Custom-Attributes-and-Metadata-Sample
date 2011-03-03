using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace Test.Extensibility
{
    /// <summary>
    /// Custom attribute for importing our MessageService
    /// 
    /// Enables us to give customers specific attributes to use, rather than relying on them knowing anything about MEF
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class ImportMessageServiceAttribute : ImportAttribute
    {
        public ImportMessageServiceAttribute() : base(typeof(IMessageService))
        {

        }
    }
}
