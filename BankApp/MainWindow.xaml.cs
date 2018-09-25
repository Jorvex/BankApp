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
using System.IO;
using System.Data.SqlClient;

namespace BankApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //DataBaseFile database = new DataBaseFile();
            InitializeComponent();
        }
        //Create this variable for manage the TextBox.
        public static string UserName { get; set; }

        private void LogInButton(object sender, RoutedEventArgs e)
        {
            string connectionString = ("Data Source=MSI-JORDI\\SQLEXPRESS;Initial Catalog = BankAppDB; Integrated Security = True");
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            UserName = User.Text;

            SqlCommand checkUser = new SqlCommand("Select Count (UserName) From UserInfo Where UserName='" + UserName + "';", conn);
            string command = checkUser.ExecuteScalar().ToString();
            
            if (command == "0")
            {
                MessageBox.Show("This username doesn't exists, make sure you have wrote it correctly.");
            }

            else
            {
                SqlCommand checkPassword = new SqlCommand("Select Password From UserInfo Where UserName='" + User.Text + "';", conn);
                string command2 = checkPassword.ExecuteScalar().ToString();

                if (Psswd.Password == command2)
                {
                    Operations_2 operations = new Operations_2();
                    this.Close();
                    operations.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Incorrect password, make sure you have wrote it correctly.");
                }
            }
        }
        private void RegisterButton(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            this.Close();
            register.ShowDialog();
        }
    }
}
