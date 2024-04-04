using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO.Packaging;
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
using System.Data;


namespace RealtyMarket
{
    /// <summary>
    /// Логика взаимодействия для Input.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Пантик\source\repos\RealtyMarket\RealtyMarket\Database1.mdf;Integrated Security=True";
       

        public InputWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }


        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Когда поле в фокусе, скрываем надпись
            if (sender is TextBox textBox)
            {
                textBox.Foreground = SystemColors.ControlTextBrush;
                if (textBox.Text == textBox.Tag?.ToString())
                {
                    textBox.Text = "";
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Когда поле теряет фокус и пустое, восстанавливаем надпись
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = Brushes.Gray;
                textBox.Text = textBox.Tag?.ToString();
            }
        }
        private bool CheckCredentials(string phoneNumber, string password)
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Пантик\source\repos\RealtyMarket\RealtyMarket\Database1.mdf;Integrated Security=True"))
                {
                    connection.Open();

                    // Запрос для проверки пароля и номера телефона
                    string query = "SELECT COUNT(*) FROM Клиенты WHERE Номер_телефона = @PhoneNumber AND Пароль = @Password";

                    // Создание команды с использованием параметров
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Password", password);

                        // Получение результата запроса
                        int count = (int)command.ExecuteScalar();

                        // Если в результате запроса получено значение больше 0, то учетные данные совпадают
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений при работе с базой данных
                MessageBox.Show($"Ошибка при проверке учетных данных: {ex.Message}");
                return false;
            }
        }

        public void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = PhoneNumberTextBox.Text;
            string password = PasswordBox.Password;

            // Вызываем метод для проверки учетных данных
            if (CheckCredentials(phoneNumber, password))
            {
                // Учетные данные верны, выполните необходимые действия для входа в приложение
                MessageBox.Show("Вход выполнен успешно!");
                Application.Current.Properties["IsLoggedIn"] = true;
                this.Close();

            }
            else
            {
                // Учетные данные неверны, вы можете показать сообщение об ошибке или выполнить другие действия
                MessageBox.Show("Неверные учетные данные. Попробуйте еще раз.");
            }
        }

       public void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            Registered registered = new Registered();
            registered.ShowDialog();
            
        }
    }
}
