using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.Entities
{
    public class User
    {
        string login;
        string password;

        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
    }
}
