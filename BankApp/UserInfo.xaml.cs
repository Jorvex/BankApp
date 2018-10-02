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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class UserInfo : Window
    {
        public UserInfo()
        {
            string connectionString = ("Data Source=MSI-JORDI\\SQLEXPRESS;Initial Catalog = BankAppDB; Integrated Security = True");
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            InitializeComponent();
            if (Register.UserName == null)
            {
                SqlCommand name = new SqlCommand("Select Name From UserInfo Where Username = '" + (MainWindow.UserName) + "';",conn);
                SqlCommand fullName = new SqlCommand("Select (Name + ' ' + LastName) From UserInfo Where Username = '" + (MainWindow.UserName) +"';", conn);
                SqlCommand balance = new SqlCommand("Select Balance From UserInfo Where Username = '" + (MainWindow.UserName) + "';", conn);
                string l_name = name.ExecuteScalar().ToString();
                string l_fullName = fullName.ExecuteScalar().ToString();
                string l_balance = balance.ExecuteScalar().ToString();
                string introduction = ($"Hello {l_name}!");
                Intro.Content = introduction;
                Name.Content = l_fullName;
                Balance.Content = ($"{l_balance}€");
            }
            else
            {
                SqlCommand name = new SqlCommand("Select Name From UserInfo Where Username = '" + (Register.UserName) +"';", conn);
                SqlCommand fullName = new SqlCommand("Select (Name + ' ' + LastName) From UserInfo Where Username = '" + (Register.UserName) + "';", conn);
                SqlCommand balance = new SqlCommand("Select Balance From UserInfo Where Username = '" + (Register.UserName) + "';", conn);
                string r_name = name.ExecuteScalar().ToString();
                string r_fullName = fullName.ExecuteScalar().ToString();
                string r_balance = balance.ExecuteScalar().ToString();
                string introduction = ($"Hello {r_name}!");
                Intro.Content = introduction;
                Name.Content = r_fullName;
                Balance.Content = ($"{r_balance}€");
            }
            conn.Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
