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
using System.Runtime.CompilerServices;
using System.ComponentModel;
using WpfApp3.ViewModels;
using ContactCatalog;
using System.Windows.Threading;
using Database;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CombinedViewModels viewModels = null;
        ProgramSettings ProgramSettings;
        public MainWindow()
        {
            SettingsLoader settingsLoader = SettingsLoader.Load();
            ProgramSettings = settingsLoader.GetSettings();
            InitializeComponent();
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            Edit edit = new Edit();
            edit.DataContext = viewModels;

            edit.ShowDialog();
        }

        private void OpenClick(object sender, RoutedEventArgs e)
        {
            if (ProgramSettings != null)
            {
                try
                {
                    Directory.Setup(ProgramSettings.ConnectionString);
                }
                catch
                {
                    SettingsWindow settingsWindow = new SettingsWindow();
                    settingsWindow.Owner = this;
                    settingsWindow.DataContext = new SettingsViewModel();
                    settingsWindow.ShowDialog();
                }
            }
            else
            {
                throw new Exception("Enter connection string");
            }

            viewModels = new CombinedViewModels();
            DataContext = viewModels;
        }

        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            Directory.Setup(ProgramSettings.ConnectionString);

            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Owner = this;
            settingsWindow.DataContext = new SettingsViewModel();
            settingsWindow.ShowDialog();
        }
    }
    
}
