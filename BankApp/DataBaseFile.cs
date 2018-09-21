using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Data.SqlClient;

namespace BankApp
{
    public class DataBaseFile
    {
        //Creates a database in txt format.
        public static string DBFile = Path.Combine(Environment.CurrentDirectory, @"DataBase.txt");

        //Checks if the file exists, if not, it will create a new one.
        public DataBaseFile()
        {
            if (!File.Exists(DBFile))
            {
                var myFile = File.Create(DBFile);
                myFile.Close();
            }
        }
        //Checks the file for find users.
        public static bool FindItem(string username)
        {
            var lines = File.ReadAllLines(DataBaseFile.DBFile).ToList();
            return lines.Any(x => x.Contains(username));
        }

        public static void OpenConnection()
        {
            
            
        }
    }
}
