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
    /// Lógica de interacción para Deposit_2.xaml
    /// </summary>
    public partial class Deposit_2 : Window
    {
        public Deposit_2()
        {
            InitializeComponent();
        }
        
        //Manages deposit button.
        private void DepositButton(object sender, RoutedEventArgs e)
        {
            if (Register.UserName == null)
            {
                try
                {
                    string connectionString = ("Data Source=MSI-JORDI\\SQLEXPRESS;Initial Catalog = BankAppDB; Integrated Security = True");
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand addValue = new SqlCommand("Update UserInfo Set Balance= Balance + '" + (DepositBox.Text) +
                    "' Where UserName= '" + (MainWindow.UserName) + "'", conn);
                    addValue.ExecuteNonQuery();
                    MessageBox.Show("Operation complete.", "Deposit");
                    conn.Close();
                    this.Close();
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
                    SqlCommand addValue = new SqlCommand("Update UserInfo Set Balance= Balance + '" + (DepositBox.Text) +
                    "' Where UserName= '" + (Register.UserName) + "'", conn);
                    addValue.ExecuteNonQuery();
                    MessageBox.Show("Operation complete.", "Deposit");
                    conn.Close();
                    this.Close();
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