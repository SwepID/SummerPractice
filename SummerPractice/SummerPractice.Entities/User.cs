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
        string fname;
        string sname;
        string password;

        public string Login { get => login; set => login = value; }
        public string Fname { get => fname; set => fname = value; }
        public string Sname { get => sname; set => sname = value; }
        public string Password { get => password; set => password = value; }
    }
}
