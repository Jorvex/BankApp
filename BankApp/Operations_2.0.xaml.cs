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
    /// Lógica de interacción para Operations_2.xaml
    /// </summary>
    public partial class Operations_2 : Window
    {
        //Principal functions.
        public Operations_2()
        {
            InitializeComponent();
        }
        //Runs the Deposit window.
        private void DepositButton(object sender, RoutedEventArgs e)
        {
            Deposit_2 deposit = new Deposit_2();
            deposit.ShowDialog();
        }
        //Runs the Withdraw window.
        private void WithdrawButton(object sender, RoutedEventArgs e)
        {
            Withdraw_2 withdraw = new Withdraw_2();
            withdraw.ShowDialog();
        }
        //Shows the current Balance of the user.
        private void BalanceButton(object sender, RoutedEventArgs e)
        {
            string connectionString = ("Data Source=MSI-JORDI\\SQLEXPRESS;Initial Catalog = BankAppDB; Integrated Security = True");
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand checkUser = new SqlCommand("Select UserName From UserInfo Where UserName='" + MainWindow.UserName + "';", conn);
            SqlCommand checkBalance = new SqlCommand("Select Balance From UserInfo Where UserName='" + MainWindow.UserName + "';", conn);
            string user = checkUser.ExecuteScalar().ToString();
            string balance = checkBalance.ExecuteScalar().ToString();
            conn.Close();
            MessageBox.Show($"{user}, your current balance is: {balance}€.","User Information");
        }
        //Runs the FindUsers window.
        private void UsersButton(object sender, RoutedEventArgs e)
        {
            FindUsers_2 users = new FindUsers_2();
            users.ShowDialog();
        }
    }
}