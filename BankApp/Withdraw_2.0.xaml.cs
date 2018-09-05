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
    /// Lógica de interacción para Withdraw_2.xaml
    /// </summary>
    public partial class Withdraw_2 : Window
    {
        public Withdraw_2()
        {
            InitializeComponent();
        }

        //Manages withdraw button.
        public string withdraw;
        private void WithdrawButton(object sender, RoutedEventArgs e)
        {
            //Removes the related quantity.
            try
            {
                string withdraw = this.withdraw;
                withdraw = WithdrawBox.Text;

                EditFile.Balance -= Int32.Parse(withdraw);
                EditFile.SaveDataToFile();
                MessageBox.Show("Successfully withdrawn.");
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