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
    /// Lógica de interacción para FindUsers.xaml
    /// </summary>
    public partial class Users : Page
    {
        public Users()
        {
            InitializeComponent();
            UserList.UsersList().ToList().ForEach(u => userListBox.Items.Add(u));
        }
        private void GoBackButton(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void userListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = sender as ListBox;
            var user = listbox.SelectedItem as Users;
            selectedUserLabel.Content = user.Name;
        }
    }
}
