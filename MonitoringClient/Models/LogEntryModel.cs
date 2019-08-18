using System;
using System.ComponentModel;
using DuplicateCheckerLib;
using LinqToDB.Mapping;

namespace MonitoringClient.Models
{
    [Table("v_logentries")]
    public class LogEntryModel : BaseModel
    {
            
        private string _pod;
        [Column("pod")]
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
        [Column("location")]
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
        [Column("hostname")]
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
        [Column("severity")]
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
        [Column("timestamp")]
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
        [Column("message")]
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        private bool Equals(LogEntryModel le)
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
            return Equals((LogEntryModel)obj);
        }

        public static bool operator ==(LogEntryModel logEntryModelA, LogEntryModel logEntryModelB)
        {
            if (ReferenceEquals(logEntryModelB, null)) return false;
            if (ReferenceEquals(logEntryModelA, null)) return false;

            return (logEntryModelA.Equals(logEntryModelB));
        }

        public static bool operator !=(LogEntryModel logEntryModelA, LogEntryModel logEntryModelB)
        {
            if (ReferenceEquals(logEntryModelA, null)) return false;

            return !(logEntryModelA == logEntryModelB);
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
