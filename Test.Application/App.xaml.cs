using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.ComponentModel.Composition;
using Test.Extensibility;
using System.ComponentModel.Composition.Hosting;
using Test.Application.Views;
using Test.Application.ViewModels;

namespace Test.Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        // Lazy importing of plugins with metadata
        [ImportMany]
        public Lazy<IPlugin, IPluginMetadata>[] Plugins { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Construct our main window
            // We create the view model here so we can tell MEF to use this instance of it, rather than create its own
            var mainWindow = new MainWindow();
            var mainViewModel = new MainViewModel();
            var mainView = new MainView(mainViewModel);
            mainWindow.Content = mainView;

            // Creat a directory (plugins) and assembly catalog (exports)
            var catalog = new DirectoryCatalog(".");
            var asmCatalog = new AssemblyCatalog(this.GetType().Assembly);

            CompositionContainer container = new CompositionContainer(new AggregateCatalog(catalog, asmCatalog));

            // Register our current instance of MainViewModel with the container
            // If we don't do this then MEF will create its own
            //
            // We only need to do this because our view and viewmodel is already constructed.
            container.ComposeExportedValue<IMessageService>(mainViewModel);

            // Wireup our plugins, which in turn wires up their imports
            container.SatisfyImportsOnce(this);

            // We can now work with the metadata and only initialise the plugins we want
            // The plugin won't even be constructed if we choose not to access "plugin.Value"
            if (Plugins != null)
            {
                foreach (var plugin in Plugins)
                {
                    // Don't load anything named "Plugin2" - we could use this for allowing users
                    // to specify plugins to load/not load at a later date.
                    //
                    // Plugin2's Main class is never constructed
                    if (plugin.Metadata.Name != "Plugin2")
                        plugin.Value.Initialise();
                }
            }

            mainWindow.Show();
        }
    }
}
