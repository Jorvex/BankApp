using System;
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

        public static void ReadFile()
        {
            var lines = File.ReadAllLines(DataBaseFile.DBFile).ToList();
            string line = lines.FirstOrDefault(x => x.Contains(UserName));
            var parts = line.Split(',');
            string user = parts[0];
            Balance = double.Parse(parts[1]);
        }
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
