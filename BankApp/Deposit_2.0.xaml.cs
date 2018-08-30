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
        public string deposit;
        private void DepositButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string deposit = this.deposit;
                deposit = DepositBox.Text;

                EditFile.Balance += Int32.Parse(deposit);
                EditFile.SaveDataToFile();
                MessageBox.Show("Successfully deposited.");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect format! Please, type only numbers.");
            }
        }

        private void GoBackButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}