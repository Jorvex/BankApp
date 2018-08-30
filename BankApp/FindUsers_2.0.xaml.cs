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
    /// Lógica de interacción para FindUsers_2.xaml
    /// </summary>
    public partial class FindUsers_2 : Window
    {
        public FindUsers_2()
        {
            InitializeComponent();
            UserList.UsersList().ToList().ForEach(u => userListBox.Items.Add(u));
        }
        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UserListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = sender as ListBox;
            var user = listbox.SelectedItem as User;
            selectedUserLabel.Content = user.Name;
        }
    }
}