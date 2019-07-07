using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuplicateCheckerLib;
using LinqToDB.Mapping;

namespace MonitoringClient.Models
{
    public class BaseModel : INotifyPropertyChanged, IEntity
    {
        private int _id;
        [PrimaryKey, Column("id")]
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
