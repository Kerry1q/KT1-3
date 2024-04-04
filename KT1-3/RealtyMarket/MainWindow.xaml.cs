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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataBase dataBase;

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputWindow inputWindow = new InputWindow();

            // Показываем новое окно
            inputWindow.Show();
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Reys reys = new Reys();

            reys.ShowDialog();
        }

        public void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Properties["IsLoggedIn"] is bool isLoggedIn && isLoggedIn)
            {
                // Открыть форму профиля или выполнить другие действия для авторизованного пользователя
                ProfileWindow profileWindow = new ProfileWindow();
                profileWindow.Show();
            }
            else
            {
                MessageBox.Show("Для доступа к профилю необходимо войти в аккаунт.");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

           

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Properties["IsLoggedIn"] is bool isLoggedIn && isLoggedIn)
            {
                MessageBox.Show("Ваша корзина пуста.");
            }

            else
            {
                MessageBox.Show("Для доступа к корзине необходимо войти в аккаунт.");
            }

        }
    }
}
