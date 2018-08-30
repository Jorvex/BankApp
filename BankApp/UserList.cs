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
        //Creates a list where will appear the created users.
        public static IEnumerable<User> UsersList()
        {
            return File.ReadAllLines(DataBaseFile.DBFile).Select(l => User.Parse(l));

        }
    }
}