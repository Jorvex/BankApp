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
            //Removes the related quantity.
            try
            {
                string connectionString = ("Data Source=MSI-JORDI\\SQLEXPRESS;Initial Catalog = BankAppDB; Integrated Security = True");
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand addValue = new SqlCommand("Update UserInfo Set Balance= Balance - '" + (WithdrawBox.Text) +
                "' Where UserName= '" + (MainWindow.UserName) + "'", conn);
                addValue.ExecuteNonQuery();
                MessageBox.Show("Operation complete.","Withdraw");
                conn.Close();
                this.Close();
            }
            //If in TextBox there are not only numbers, will appear a error message.
            catch (SqlException)
            {
                MessageBox.Show("Incorrect format! Please type only numbers.");
            }
        }
        //Close the window.
        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}