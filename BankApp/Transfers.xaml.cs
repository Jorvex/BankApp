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
using System.Data.SqlClient;

namespace BankApp
{
    /// <summary>
    /// Lógica de interacción para FindUsers_2.xaml
    /// </summary>
    public partial class Transfers : Window
    {
        public Transfers()
        {
            InitializeComponent();
            //Create a list and adds all users detected on DB file to this list.

            string connectionString = ("Data Source=MSI-JORDI\\SQLEXPRESS;Initial Catalog = BankAppDB; Integrated Security = True");
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string command = "Select UserName From UserInfo;";
            SqlCommand checkUser = new SqlCommand(command, conn);
            SqlDataReader reader = checkUser.ExecuteReader();

            userListBox.Items.Clear();

            while (reader.Read())
            {
                userListBox.Items.Add(reader.GetString(0));
            }

            reader.Close();
            conn.Close();
            userListBox.EndInit();
        }

        private void TransferButton(object sender, RoutedEventArgs e)
        {
            string user = userListBox.SelectedItem.ToString();

            string connectionString = ("Data Source=MSI-JORDI\\SQLEXPRESS;Initial Catalog = BankAppDB; Integrated Security = True");
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand logInUser = new SqlCommand("Select UserName From UserInfo Where UserName='" + MainWindow.UserName + "';", conn);
            SqlCommand registerUser = new SqlCommand("Select UserName From UserInfo Where UserName='" + Register.UserName + "';", conn);
            SqlCommand logInBalance = new SqlCommand("Select Balance From UserInfo Where UserName='" + MainWindow.UserName + "';", conn);
            SqlCommand registerBalance = new SqlCommand("Select Balance From UserInfo Where UserName='" + Register.UserName + "';", conn);
            if (user != null)
            {
                if (user != MainWindow.UserName)
                {
                    if (MainWindow.UserName == null)
                    {
                        try
                        {
                            SqlCommand getBalance = new SqlCommand("Select Balance From UserInfo Where UserName= '" + (Register.UserName) + "'", conn);
                            int command = Convert.ToInt32(getBalance.ExecuteScalar());
                            int result = command - int.Parse(t_Balance.Text);
                            if (result >= 0)
                            {
                                MessageBoxResult message = MessageBox.Show($"Are you sure do you want to transfer {t_Balance.Text}€ to {user}?", "Transfer", MessageBoxButton.YesNo);
                                switch (message)
                                {
                                    case MessageBoxResult.Yes:
                                        string r_user = registerUser.ExecuteScalar().ToString();
                                        string r_balance = registerBalance.ExecuteScalar().ToString();
                                        SqlCommand transfer_1 = new SqlCommand("Update UserInfo Set Balance= Balance - '" + (t_Balance.Text) +
                                        "' Where UserName= '" + (Register.UserName) + "'", conn);
                                        SqlCommand transfer_2 = new SqlCommand("Update UserInfo Set Balance= Balance + '" + (t_Balance.Text) +
                                        "' Where UserName= '" + (user) + "'", conn);
                                        transfer_1.ExecuteNonQuery();
                                        transfer_2.ExecuteNonQuery();
                                        MessageBox.Show("Transfer completed.");
                                        this.Close();
                                        break;

                                    case MessageBoxResult.No:
                                        break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("You don't have enough money to transfer this quantity.", "Error");
                            }
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Incorrect format! Please type only numbers.", "Error");
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Incorrect format! Please type only numbers.", "Error");
                        }
                    }
                    else
                    {
                        try
                        {
                            SqlCommand getBalance = new SqlCommand("Select Balance From UserInfo Where UserName= '" + (MainWindow.UserName) + "'", conn);
                            int command = Convert.ToInt32(getBalance.ExecuteScalar());
                            int result = command - int.Parse(t_Balance.Text);
                            if (result >= 0)
                            {
                                MessageBoxResult message = MessageBox.Show($"Are you sure do you want to transfer {t_Balance.Text}€ to {user}?", "Transfer", MessageBoxButton.YesNo);
                                switch (message)
                                {
                                    case MessageBoxResult.Yes:
                                        string r_user = logInUser.ExecuteScalar().ToString();
                                        string r_balance = logInBalance.ExecuteScalar().ToString();
                                        SqlCommand transfer_1 = new SqlCommand("Update UserInfo Set Balance= Balance - '" + (t_Balance.Text) +
                                        "' Where UserName= '" + (MainWindow.UserName) + "'", conn);
                                        SqlCommand transfer_2 = new SqlCommand("Update UserInfo Set Balance= Balance + '" + (t_Balance.Text) +
                                        "' Where UserName= '" + (user) + "'", conn);
                                        transfer_1.ExecuteNonQuery();
                                        transfer_2.ExecuteNonQuery();
                                        MessageBox.Show("Transfer completed.");
                                        this.Close();
                                        break;

                                    case MessageBoxResult.No:
                                        break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("You don't have enough money to transfer this quantity.", "Error");
                            }
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Incorrect format! Please type only numbers.", "Error");
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Incorrect format! Please type only numbers.", "Error");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You're not able to transfer money to yourself.","Error");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please first select a user for do the transfer.","Error");
            }
        }

        //Close the window.
        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}