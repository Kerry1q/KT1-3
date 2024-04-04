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
using System.Data.SqlClient;

namespace RealtyMarket
{
    /// <summary>
    /// Логика взаимодействия для Registered.xaml
    /// </summary>
    public partial class Registered : Window
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Пантик\source\repos\RealtyMarket\RealtyMarket\Database1.mdf;Integrated Security=True";
        public Registered()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = PhoneNumberTextBox.Text;
            string password = PasswordTextBox.Password;
            string fullName = FullNameTextBox.Text;

            // Выполняем операцию вставки в базу данных
            if (InsertDataIntoDatabase(phoneNumber, password, fullName))
            {
                MessageBox.Show("Учетная запись успешно создана!");
            }
            else
            {
                MessageBox.Show("Ошибка при создании учетной записи.");
            }
        }
        private bool InsertDataIntoDatabase(string phoneNumber, string password, string fullName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Замените "Clients" на ваше имя таблицы
                    string query = "INSERT INTO Клиенты (Номер_телефона, Пароль, ФИО) VALUES (@PhoneNumber, @Password, @FullName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Защита от SQL-инъекций
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@FullName", fullName);

                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при вставке данных в базу данных: {ex.Message}");
                return false;
            }
        }
    }
}


