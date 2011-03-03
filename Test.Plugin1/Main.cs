using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Extensibility;
using System.Timers;

namespace Test.Plugin1
{
    // We use our own stongly type export attribute with custom metadata (plugin name)
    [ExportPlugin("Plugin1")]
    public class Main : IPlugin
    {
        // We use our own import attribute
        [ImportMessageService]
        public IMessageService MessageService { get; set; }

        public void Initialise()
        {
            if (MessageService == null)
                throw new ArgumentNullException("MessageService");

            Timer timer = new Timer(2000);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MessageService.ShowMessage("Ping from Plugin1!");
        }
    }
}
