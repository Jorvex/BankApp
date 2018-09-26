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
using System.IO;
using System.Data.SqlClient;

namespace BankApp
{
    /// <summary>
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        public static string UserName { get; set; }

        private void RegisterBttn(object sender, RoutedEventArgs e)
        {
            UserName = User.Text;

            string connectionString = ("Data Source=MSI-JORDI\\SQLEXPRESS;Initial Catalog = BankAppDB; Integrated Security = True");
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand checkUser = new SqlCommand("Select Count (UserName) From UserInfo Where UserName='" + User.Text + "';", conn);
            string command = checkUser.ExecuteScalar().ToString();

            if (command == "1")
            {
                MessageBox.Show("This username already exists, please try with another one.");
            }
            
            else
            {
                if (ConfirmPsswd.Password.Length < 6)
                {
                    MessageBox.Show("The password lenght is less than 6 characters, please try again.");
                }

                else
                {
                    if (Psswd.Password == ConfirmPsswd.Password)
                    {
                        MessageBoxResult result = MessageBox.Show($"Are you sure do you want to create the user: {User.Text}?", "Register", MessageBoxButton.YesNo);
                        switch (result)
                        {
                            case MessageBoxResult.Yes:
                                SqlCommand createUser = new SqlCommand("Insert Into UserInfo (UserName, Balance, Password) Values" +
                                    " ('" + User.Text + "', '0', '" + ConfirmPsswd.Password + "')", conn);
                                createUser.ExecuteNonQuery();
                                Operations_2 operations = new Operations_2();
                                conn.Close();
                                this.Close();
                                operations.ShowDialog();
                                break;

                            case MessageBoxResult.No:
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The password doesn't match, make sure you have wrote it correctly.");
                    }
                }
            }
            conn.Close();
        }
        private void GoBackBttn(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }
    }
}
