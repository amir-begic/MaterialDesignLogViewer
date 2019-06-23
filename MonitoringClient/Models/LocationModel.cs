using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringClient.Models
{
    public class LocationModel :  BaseModel
    {
        private int _address_fk;

        public int AddressForeignKey
        {
            get => _address_fk;
            set
            {
                _address_fk = value;
                OnPropertyChanged("AddressForeignKey");
            }
        }

        private string _designation;

        public string Designation
        {
            get => _designation;
            set
            {
                _designation = value;
                OnPropertyChanged("Designation");
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

        private int _building;
        public int Building
        {
            get => _building;
            set
            {
                _building = value;
                OnPropertyChanged("Building");
            }
        }

        private int _room;
        public int Room
        {
            get => _room;
            set
            {
                _room = value;
                OnPropertyChanged("Room");
            }
        }
    }
}
