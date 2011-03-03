using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Extensibility
{
    /// <summary>
    /// Basic plugin interface
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Called if and when the plugin is loaded
        /// </summary>
        void Initialise();
    }
}
