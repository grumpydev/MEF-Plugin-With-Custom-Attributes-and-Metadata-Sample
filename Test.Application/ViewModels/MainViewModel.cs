using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Test.Extensibility;
using System.Windows.Threading;

namespace Test.Application.ViewModels
{
    [Export(typeof(IMessageService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MainViewModel : INotifyPropertyChanged, IMessageService
    {
        private Dispatcher _Dispatcher;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<string> _Items;
        public ObservableCollection<string> Items
        {
            get
            {
                return _Items;
            }
            private set
            {
                _Items = value;
                RaisePropertyChanged("Items");
            }
        }

        private void RaisePropertyChanged(string property)
        {
            var evt = this.PropertyChanged;

            if (evt != null)
                evt.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public MainViewModel()
        {
            _Dispatcher = Dispatcher.CurrentDispatcher;

            Items = new ObservableCollection<string>();
            Items.Add("Messages go here");
        }

        public void ShowMessage(string message)
        {
            _Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate { Items.Add(message); });
        }
    }
}
