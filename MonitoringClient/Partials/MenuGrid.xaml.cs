using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DuplicateCheckerLib;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MonitoringClient.Services;
using MonitoringClient.ViewModels;

namespace MonitoringClient.Partials
{
    /// <summary>
    /// Interaction logic for MenuGrid.xaml
    /// </summary>
    public partial class MenuGrid : UserControl
    {
        public MenuGrid()
        {
            InitializeComponent();


            DataContext = new MenuGridViewModel();
        }


        private async void CloseApplicationButton_OnClick(object sender, RoutedEventArgs e)
        {
            var closeApplicationDialog = new CloseApplicationDialog();

            await DialogHost.Show(closeApplicationDialog, "RootDialog");
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }
    }
}
