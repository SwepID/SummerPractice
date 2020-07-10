using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.Models
{
    [Table("Users")]
    public class User
    {
        int id;
        string login;
        string fname;
        string sname;
        string password;
        IEnumerable<Skill> skillList;
        

        public User(string login, string fname, string sname, string password, IEnumerable<Skill> skills)
        {
            this.login = login;
            this.fname = fname;
            this.sname = sname;
            this.password = password;
            this.skillList = skills;
        }

        public User()
        {

        }
        [Key]
        public int Id { get => id; set => id = value; }
        [Required]
        public string Login { get => login; set => login = value; }
        [Required]
        public string Fname { get => fname; set => fname = value; }
        [Required]
        public string Sname { get => sname; set => sname = value; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get => password; set => password = value; }
        public IEnumerable<Skill> SkillList{get => skillList; set => skillList = value; }
        
    }
}
