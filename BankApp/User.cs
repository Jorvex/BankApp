using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class User
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

        public static User Parse(string userLine)
        {
            var parts = userLine.Split(',');
            return new User
            {
                Name = parts[0],
                Balance = double.Parse(parts[1])
            };
        }

    }
}
