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

namespace BankApp
{
    /// <summary>
    /// Lógica de interacción para Operations.xaml
    /// </summary>
    public partial class Operations : Page
    {
        public Operations()
        {
            InitializeComponent();
        }

        private void DepositButton(object sender, RoutedEventArgs e)
        {
            Deposit deposit = new Deposit();
            this.NavigationService.Navigate(deposit);
        }

        private void ExtractButton(object sender, RoutedEventArgs e)
        {
            Extract extract = new Extract();
            this.NavigationService.Navigate(extract);
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
            Users users = new Users();
            this.NavigationService.Navigate(users);
        }
    }
}
