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
using System.IO;

namespace BankApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataBaseFile database = new DataBaseFile();
            InitializeComponent();
        }
        //Create this variable for manage the TextBox.
        public string content;
        private void LogInButton(object sender, RoutedEventArgs e)
        {
            string content = this.content;
            content = User.Text;

            //If the user already exists, it will continue to the next window.
            if (DataBaseFile.FindItem(content))
            {
                EditFile.UserName = content;
                EditFile.ReadFile();
                if (Psswd.Password == EditFile.Password)
                {
                    Operations_2 operations = new Operations_2();
                    this.Close();
                    operations.ShowDialog();
                }
                if (Psswd.Password == "")
                {
                    MessageBox.Show("Please type your password.", "Error");
                }
                else
                {
                    MessageBox.Show("Incorrect Password","Error");
                }
            }
            
            //If not, it will inform to use Register function.
            else
            {
                MessageBox.Show($"There are no matches using '{content}' as user, if you are not registered, use the Register function.", "Log In");
            }

        }
        private void RegisterButton(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            this.Close();
            register.ShowDialog();
        }
    }
}
