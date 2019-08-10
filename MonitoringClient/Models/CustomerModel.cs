using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MonitoringClient.Models
{
    [Table("Customer")]
    public class CustomerModel : BaseModel
    {
        private int person_fk;
        [Column("person_fk")]
        public int Person {
            get => person_fk;
            set
            {
                person_fk = value;
                OnPropertyChanged("Person");
            }
        }

        public int address_fk;
        [Column("address_fk")]
        public int Address
        {
            get => address_fk;
            set
            {
                address_fk = value;
                OnPropertyChanged("Address");
            }
        }

        private string kundenkonto_fk;
        [Column("kundenkonto_fk")]
        public string CustomerNr
        {
            get => kundenkonto_fk;
            set
            {
                kundenkonto_fk = value;
                OnPropertyChanged("CustomerNr");
            }
        }

        private string tel;
        [Column("tel")]
        public string TelephoneNr
        {
            get => tel;
            set
            {
                tel = value;
                OnPropertyChanged("TelephoneNr");
            }
        }

        private string auth;
        [Column("auth")]
        public string Password
        {
            get => auth;
            set
            {
                auth = value;
                OnPropertyChanged("Password");
            }
        }

        private string url;
        [Column("url")]
        public string Website
        {
            get => url;
            set
            {
                url = value;
                OnPropertyChanged("Website");
            }
        }

        private string email;
        [Column("eMail")]
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        
}
}
