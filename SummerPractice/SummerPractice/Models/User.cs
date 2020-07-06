using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.Models
{
    public class User
    {
        string login;
        string fname; 
        string sname;
        string password;

        public User(string login, string fname, string sname, string password)
        {
            this.login = login;
            this.fname = fname;
            this.sname = sname;
            this.password = password;
        }

        public User()
        {

        }
        [Key]
        public string Login { get => login; set => login = value; }
        public string Fname { get => fname; set => fname = value; }
        public string Sname { get => sname; set => sname = value; }
        public string Password { get => password; set => password = value; }
    }
}
