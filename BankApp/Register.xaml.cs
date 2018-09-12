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
            
            //Check if the user already exists.
            if (DataBaseFile.FindItem(user))
            {
                EditFile.UserName = user;
                EditFile.ReadFile();
                MessageBox.Show($"The user '{user}' already exists, please try with another one.","Error");
            }

            //Check if both fields are filled.
            else
            {
                if (Psswd.Password == "" || ConfirmPsswd.Password == "")
                {
                    MessageBox.Show("Please fill both password fields.", "Error");
                }

                else
                {
                    //Checks if the password matchs.
                    if (Psswd.Password != ConfirmPsswd.Password)
                    {
                        MessageBox.Show("The password does not match. Please try again.", "Error");
                    }

                    else
                    {
                        //Check if the password meets the minimum length.
                        if (ConfirmPsswd.Password.Length >= 6)
                        {
                            MessageBoxResult result = MessageBox.Show($"Are you sure you want to register as '{user}'? ", "Register", MessageBoxButton.YesNo);
                            switch (result)
                            {
                                case MessageBoxResult.Yes:
                                {
                                    var lines_2 = File.ReadAllLines(DataBaseFile.DBFile).ToList();
                                    EditFile.UserName = user;
                                    EditFile.Password = ConfirmPsswd.Password;
                                    lines_2.Add($"{user}|{EditFile.Balance}|{ConfirmPsswd.Password}");

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

                        else
                        {
                            MessageBox.Show("The password does not contain the minimum of characters.", "Error");
                        }
                    }
                }
            }
        }

        private void GoBackBttn(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }
    }
}
