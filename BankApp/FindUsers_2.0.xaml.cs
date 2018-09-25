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
    public partial class FindUsers_2 : Window
    {
        public FindUsers_2()
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
        //Close the window.
        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}