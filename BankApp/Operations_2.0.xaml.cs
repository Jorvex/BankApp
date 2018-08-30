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

namespace BankApp
{
    /// <summary>
    /// Lógica de interacción para Operations_2.xaml
    /// </summary>
    public partial class Operations_2 : Window
    {
        public Operations_2()
        {
            InitializeComponent();
        }

        private void DepositButton(object sender, RoutedEventArgs e)
        {
            Deposit_2 deposit = new Deposit_2();
            deposit.ShowDialog();
        }

        private void ExtractButton(object sender, RoutedEventArgs e)
        {
            Extract_2 extract = new Extract_2();
            extract.ShowDialog();
        }

        public delegate void Message(string message);
        public void MessageAction(string message)
        {
            var del = MessageBox.Show(message);
        }

        private void BalanceButton(object sender, RoutedEventArgs e)
        {
            Message action = MessageAction;
            action($"{EditFile.UserName}, your current balance is: {EditFile.Balance}€.");
        }

        private void UsersButton(object sender, RoutedEventArgs e)
        {
            FindUsers_2 users = new FindUsers_2();
            users.ShowDialog();
        }
    }
}