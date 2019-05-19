using System;
using System.ComponentModel;

namespace MonitoringClient.Models
{
    public class LogEntry : INotifyPropertyChanged
    {

        private int _id;
        public int Id {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _pod;

        public string Pod
        {
            get => _pod;
            set
            {
                _pod = value;
                OnPropertyChanged("Pod");
            }
        }

        private string _location;

        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged("Value");
            }
        }

        private string _hostname;
        public string Hostname
        {
            get => _hostname;
            set
            {
                _hostname = value;
                OnPropertyChanged("Hostname");
            }
        }

        private int _severity;
        public int Severity
        {
            get => _severity;
            set
            {
                _severity = value;
                OnPropertyChanged("Severity");
            }
        }

        private DateTime _timestamp;
        public DateTime Timestamp
        {
            get => _timestamp;
            set
            {
                _timestamp = value;
                OnPropertyChanged("Value");
            }
        }

        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
