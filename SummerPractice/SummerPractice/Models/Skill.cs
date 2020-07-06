using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.Models
{
    [Table("Skills")]
    public class Skill
    {
        int id;
        string skillName;
        string description;
        IEnumerable<User> users;

        public string SkillName { get => skillName; set => skillName = value; }
        public string Description { get => description; set => description = value; }
        [Key]
        public int Id { get => id; set => id = value; }
        public IEnumerable<User> Users { get => users; set => users = value; }

        public Skill(int id, string skillName, string description, IEnumerable<User> users)
        {
            Id = id;
            SkillName = skillName;
            Description = description;
            Users = users;
        }

        public Skill()
        {

        }
    }
}
