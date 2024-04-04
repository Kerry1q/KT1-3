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
using System.Data.SqlClient;
using System.Data;

namespace RealtyMarket
{
    /// <summary>
    /// Логика взаимодействия для Reys.xaml
    /// </summary>
    public partial class Reys : Window
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Пантик\source\repos\RealtyMarket\RealtyMarket\Database1.mdf;Integrated Security=True";
        public Reys()
        {

            InitializeComponent();                     
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Airport", connection);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    airportDataGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveChanges();
            MessageBox.Show("Данные успешно обновлены!");
        }

        private void SaveChanges()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Определите команду SQL UPDATE для вашей таблицы
                    string updateCommand = "UPDATE Airport SET Napravlenie = @Napravlenie, Samolet = @Samolet, " +
                                           "Aviakompaniya = @Aviakompaniya, Vremya_pribyitia = @Vremya_pribyitia, " +
                                           "Vremya_otpravlenia = @Vremya_otpravlenia WHERE ID = @ID";

                    SqlCommand updateCmd = new SqlCommand(updateCommand, connection);
                    updateCmd.Parameters.Add("@Napravlenie", SqlDbType.NVarChar, 255, "Napravlenie");
                    updateCmd.Parameters.Add("@Samolet", SqlDbType.NVarChar, 255, "Samolet");
                    updateCmd.Parameters.Add("@Aviakompaniya", SqlDbType.NVarChar, 255, "Aviakompaniya");
                    updateCmd.Parameters.Add("@Vremya_pribyitia", SqlDbType.DateTime, 0, "Vremya_pribyitia");
                    updateCmd.Parameters.Add("@Vremya_otpravlenia", SqlDbType.DateTime, 0, "Vremya_otpravlenia");
                    updateCmd.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.UpdateCommand = updateCmd;

                    // Получите измененные данные из DataGrid
                    DataTable changes = ((DataView)airportDataGrid.ItemsSource).Table.GetChanges();

                    if (changes != null)
                    {
                        dataAdapter.Update(changes);
                        ((DataView)airportDataGrid.ItemsSource).Table.AcceptChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
