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
using System.Windows.Shapes;
using WpfApp3.ViewModels;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void AddNewOrganization(object sender, RoutedEventArgs e)
        {
            AddNewOrganization addNewOrganization = new AddNewOrganization();
            addNewOrganization.DataContext = this.DataContext;
            addNewOrganization.ShowDialog();
        }

        private void AddNewCommunicationType(object sender, RoutedEventArgs e)
        {
            AddNewCommunicationType addNewCommunicationType = new AddNewCommunicationType();
            addNewCommunicationType.DataContext = this.DataContext;
            addNewCommunicationType.ShowDialog();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
