using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringClient.Models.UI
{
    public class MenuItem : INotifyPropertyChanged
    {
        private string _name;
        private object _content;

        public string Name
        {
            get { return _name; }
            set
            {
                _content = value;
                OnPropertyChanged("Name");
            }
        }
        public object Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged("Content");
            }
        }

        public MenuItem(string name, object content)
        {
            _name = name;
            _content = content;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
