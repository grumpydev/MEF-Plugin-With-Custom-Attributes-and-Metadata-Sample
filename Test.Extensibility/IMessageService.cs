using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Extensibility
{
    /// <summary>
    /// Basic extensibility interface exposed by our application
    /// </summary>
    public interface IMessageService
    {
        void ShowMessage(string message);
    }
}
