using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace MonitoringClient.Models
{
    [Table("location")]
    public class LocationModel :  BaseModel
    {
        private int _address_fk;
        [Column("address_fk")]
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
        [Column("designation")]
        public string Designation
        {
            get => _designation;
            set
            {
                _designation = value;
                OnPropertyChanged("Designation");
            }
        }

        private int _building;
        [Column("building")]
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
        [Column("room")]
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
