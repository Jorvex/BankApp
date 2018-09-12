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
    /// Lógica de interacción para Deposit_2.xaml
    /// </summary>
    public partial class Deposit_2 : Window
    {
        public Deposit_2()
        {
            InitializeComponent();
        }
        
        //Manages deposit button.
        public string deposit;
        private void DepositButton(object sender, RoutedEventArgs e)
        {
            //Adds the related quantity.
            try
            {
                string deposit = this.deposit;
                deposit = DepositBox.Text;

                EditFile.Balance += Double.Parse(deposit);
                EditFile.SaveDataToFile();
                MessageBox.Show("Successfully deposited.");
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