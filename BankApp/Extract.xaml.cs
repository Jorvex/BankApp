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
    /// Lógica de interacción para Extract.xaml
    /// </summary>
    public partial class Extract : Page
    {
        public Extract()
        {
            InitializeComponent();
        }

        public string extract;
        private void ExtractButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string extract = this.extract;
                extract = Extraccion.Text;

                EditFile.Balance -= Int32.Parse(extract);
                EditFile.SaveDataToFile();
                MessageBox.Show("Successfully extracted.");

                //Go back to main menu.
                this.NavigationService.GoBack();
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect format! Please, type only numbers.");
            }
        }

        private void GoBackButton(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
