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
    /// Lógica de interacción para Extract_2.xaml
    /// </summary>
    public partial class Extract_2 : Window
    {
        public Extract_2()
        {
            InitializeComponent();
        }

        //Manages extract button.
        public string extract;
        private void ExtractButton(object sender, RoutedEventArgs e)
        {
            //Removes the related quantity.
            try
            {
                string extract = this.extract;
                extract = ExtractBox.Text;

                EditFile.Balance -= Int32.Parse(extract);
                EditFile.SaveDataToFile();
                MessageBox.Show("Successfully extracted.");
                //Close the window.
                this.Close();
            }
            //If in TextBox there are not only numbers, will appear a error message.
            catch (FormatException)
            {
                MessageBox.Show("Incorrect format! Please, type only numbers.");
            }
        }
        //Close the window.
        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}