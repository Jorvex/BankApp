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
    /// Lógica de interacción para Withdraw_2.xaml
    /// </summary>
    public partial class Withdraw_2 : Window
    {
        public Withdraw_2()
        {
            InitializeComponent();
        }

        //Manages withdraw button.
        private void WithdrawButton(object sender, RoutedEventArgs e)
        {
            if (Register.UserName == null)
            {
                try
                {
                    string connectionString = ("Data Source=MSI-JORDI\\SQLEXPRESS;Initial Catalog = BankAppDB; Integrated Security = True");
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand getBalance = new SqlCommand("Select Balance From UserInfo Where UserName= '" + (MainWindow.UserName) + "'", conn);
                    int command = Convert.ToInt32(getBalance.ExecuteScalar());
                    int result = command - int.Parse(WithdrawBox.Text);
                    if (result < 0)
                    {
                        MessageBox.Show("You don't have enough money to withdraw this quantity.", "Error");
                    }
                    else
                    {
                        SqlCommand addValue = new SqlCommand("Update UserInfo Set Balance= Balance - '" + (WithdrawBox.Text) +
                    "' Where UserName= '" + (MainWindow.UserName) + "'", conn);
                        addValue.ExecuteNonQuery();
                        MessageBox.Show("Operation complete.", "Deposit");
                        conn.Close();
                        this.Close();
                    }

                }
                //If in TextBox there are not only numbers, will appear a error message.
                catch (SqlException)
                {
                    MessageBox.Show("Incorrect format! Please type only numbers.", "Error");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Incorrect format! Please type only numbers.", "Error");
                }
            }
            //Adds the related quantity.
            else
            {
                //Removes the related quantity.
                try
                {
                    string connectionString = ("Data Source=MSI-JORDI\\SQLEXPRESS;Initial Catalog = BankAppDB; Integrated Security = True");
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand getBalance = new SqlCommand("Select Balance From UserInfo Where UserName= '" + (Register.UserName) + "'", conn);
                    int command = Convert.ToInt32(getBalance.ExecuteScalar());
                    int result = command - int.Parse(WithdrawBox.Text);
                    if (result < 0)
                    {
                        MessageBox.Show("You don't have enough money to withdraw this quantity.", "Error");
                    }
                    else
                    {
                        SqlCommand addValue = new SqlCommand("Update UserInfo Set Balance= Balance - '" + (WithdrawBox.Text) +
                    "' Where UserName= '" + (Register.UserName) + "'", conn);
                        addValue.ExecuteNonQuery();
                        MessageBox.Show("Operation complete.", "Deposit");
                        conn.Close();
                        this.Close();
                    }

                }
                //If in TextBox there are not only numbers, will appear a error message.
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
        //Close the window.
        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}