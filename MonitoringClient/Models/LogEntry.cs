using System;
using System.ComponentModel;
using DuplicateCheckerLib;

namespace MonitoringClient.Models
{
    public class LogEntry : INotifyPropertyChanged, IEntity
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

        private bool Equals(LogEntry le)
        {
            if (le == null) return false;

            return string.Equals(this.Message, le.Message) &&
                   this.Severity == le.Severity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LogEntry)obj);
        }

        public static bool operator ==(LogEntry logEntryA, LogEntry logEntryB)
        {
            if (ReferenceEquals(logEntryB, null)) return false;
            if (ReferenceEquals(logEntryA, null)) return false;

            return (logEntryA.Equals(logEntryB));
        }

        public static bool operator !=(LogEntry logEntryA, LogEntry logEntryB)
        {
            if (ReferenceEquals(logEntryA, null)) return false;

            return !(logEntryA == logEntryB);
        }

        public override int GetHashCode()
        {
            int hash = 41;
            hash = (hash * 7) + Severity.GetHashCode();
            hash = (hash * 7) + (!object.ReferenceEquals(null, Message) ? Message.GetHashCode() : 0);
            return hash;

        }
    }
}
