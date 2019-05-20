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
using ContactCatalog;
using WpfApp3.ViewModels;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Edit : Window
    {
      
        public Edit()
        {
            InitializeComponent();
        }
              
        private void NewOrganization(object sender, RoutedEventArgs e)
        {
            AddNewOrganization addNewOrganization = new AddNewOrganization();
            addNewOrganization.DataContext = this.DataContext;
            addNewOrganization.Show();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
        
        private void NewCommunicationMethod(object sender, RoutedEventArgs e)
        {
            AddNewCommunicationMethod addNewCommunicationMethod = new AddNewCommunicationMethod();
            addNewCommunicationMethod.Owner = this;
            addNewCommunicationMethod.DataContext = this.DataContext;
            addNewCommunicationMethod.ShowDialog();

        }
    }
}
