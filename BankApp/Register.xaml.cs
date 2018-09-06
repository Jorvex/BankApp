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
using System.IO;

namespace BankApp
{
    /// <summary>
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        public string Username;

        private void RegisterBttn(object sender, RoutedEventArgs e)
        {
            string user = this.Username;
            user = User.Text;
            
            if (DataBaseFile.FindItem(user))
            {
                EditFile.UserName = user;
                EditFile.ReadFile();
                MessageBox.Show($"The user '{user}' already exists, please try with another one.");
            }

            else
            {
                if (Psswd.Password != ConfirmPsswd.Password)
                {
                    MessageBox.Show("The password does not match. Please try again.");
                }

                if (Psswd.Password == ConfirmPsswd.Password)
                {
                    MessageBoxResult result = MessageBox.Show($"Are you sure you want to register as '{user}'? ", "Register", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            {
                                var lines_2 = File.ReadAllLines(DataBaseFile.DBFile).ToList();
                                EditFile.UserName = user;
                                lines_2.Add($"{user},{EditFile.Balance}");

                                File.WriteAllLines(DataBaseFile.DBFile, lines_2);
                                Operations_2 NewWindow = new Operations_2();
                                this.Close();
                                NewWindow.ShowDialog();
                                break;
                            }
                        case MessageBoxResult.No:
                            {
                                break;
                            }
                    }
                }
            }
        }
    }
}
