﻿using System;
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
using System.Data.SqlClient;

namespace BankApp
{
    /// <summary>
    /// Lógica de interacción para Operations_2.xaml
    /// </summary>
    public partial class Operations_2 : Window
    {
        //Principal functions.
        public Operations_2()
        {
            InitializeComponent();
        }
        //Runs the Deposit window.
        private void DepositButton(object sender, RoutedEventArgs e)
        {
            Deposit_2 deposit = new Deposit_2();
            deposit.ShowDialog();
        }
        //Runs the Withdraw window.
        private void WithdrawButton(object sender, RoutedEventArgs e)
        {
            UserInfo_2 withdraw = new UserInfo_2();
            withdraw.ShowDialog();
        }
        //Shows the current Balance of the user.
        private void BalanceButton(object sender, RoutedEventArgs e)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.Show();
        }
        //Runs the FindUsers window.
        private void UsersButton(object sender, RoutedEventArgs e)
        {
            Transfers users = new Transfers();
            users.ShowDialog();
        }
    }
}