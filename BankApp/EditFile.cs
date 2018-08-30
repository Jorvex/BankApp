﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankApp
{
    class EditFile
    {
        public static string UserName { get; set; }
        public static double Balance { get; set; }

        //Checks the lines of the DB file.
        public static void ReadFile()
        {
            var lines = File.ReadAllLines(DataBaseFile.DBFile).ToList();
            //The next line allows to only edit the current User that has logged in.
            string line = lines.FirstOrDefault(x => x.Contains(UserName));
            var parts = line.Split(',');
            string user = parts[0];
            Balance = double.Parse(parts[1]);
        }
        //Saves all data in database file.
        public static void SaveDataToFile()
        {
            var lines = File.ReadAllLines(DataBaseFile.DBFile).ToList();

            lines = lines.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                var parts = line.Split(',');
                string user = parts[0];

                if (user == UserName)
                {
                    line = $"{UserName},{Balance}";
                    lines[i] = line;
                    break;
                }
            }
            File.WriteAllLines(DataBaseFile.DBFile, lines);
        }
    }
}
