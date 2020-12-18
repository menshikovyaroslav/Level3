using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models.Base;

namespace WpfApp1.Models
{
    [Table(Name = "Servers")]
    public class Server : INotifyPropertyChanged
    {
        private int port { get; set; }

        [Column]
        public int Id { get; set; }
        [Column]
        public bool IsSSL { get; set; }
        [Column]
        public string Address { get; set; }
        [Column]
        public int Port { get { return port; } set { port = value; OnPropertyChanged(); } }

        public string FullAddress { get { return $"{Address}:{Port}"; } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
