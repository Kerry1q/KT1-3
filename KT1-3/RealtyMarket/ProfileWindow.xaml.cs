using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace RealtyMarket
{
    /// <summary>
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
      
        public ProfileWindow()
        {
            InitializeComponent();
           
        }

        

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрываем текущее окно
            this.Close();
            Application.Current.Properties["IsLoggedIn"] = false;

            // Открываем окно MainWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

       

        private void DeleteAdButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditAdButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditProfileButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
