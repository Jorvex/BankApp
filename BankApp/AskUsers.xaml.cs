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
    /// Lógica de interacción para AskUser.xaml
    /// </summary>
    public partial class AskUsers : Page
    {
        public SizeToContent SizeToContent { get; set; }
        public AskUsers()
        {
            DataBaseFile database = new DataBaseFile();
            this.SizeToContent = SizeToContent.WidthAndHeight;
            InitializeComponent();
        }

        public string content;
        private void LogInButton(object sender, RoutedEventArgs e)
        {
            string content = this.content;
            content = Content.Text;

            if (DataBaseFile.UserExists(content))
            {
                EditFile.UserName = content;
                EditFile.ReadFile();
                Operations operations = new Operations();
                this.NavigationService.Navigate(operations);
            }
            else
            {
                MessageBoxResult Reply = MessageBox.Show("There are no matches in database, do you want to create a new one?", "Log In", MessageBoxButton.YesNo);
                switch (Reply)
                {
                    case MessageBoxResult.Yes:
                        MessageBox.Show($"Usuario creado como {content}.");

                        var lines = File.ReadAllLines(DataBaseFile.DBFile).ToList();
                        EditFile.UserName = content;
                        lines.Add($"{content},{EditFile.Balance}");

                        File.WriteAllLines(DataBaseFile.DBFile, lines);
                        Operations NewWindow = new Operations();
                        this.NavigationService.Navigate(NewWindow);
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }

        }
    }
}
