using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankApp
{
    class UserList : EditFile
    {
        public static IEnumerable<User> UsersList()
        {
            return File.ReadAllLines(DataBaseFile.DBFile).Select(l => User.Parse(l));

        }
    }
}