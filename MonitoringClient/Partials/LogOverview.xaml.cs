using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MonitoringClient.ViewModels;

namespace MonitoringClient.Partials
{
    /// <summary>
    /// Interaction logic for LogOverview.xaml
    /// </summary>
    public partial class LogOverview : UserControl
    {
        public LogOverview()
        {
            InitializeComponent();
            DataContext = new LogOverviewViewModel();
        }
    }
}
