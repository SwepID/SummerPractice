using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.Models
{
    public class Skill
    {
        string skillName;
        string description;

        public string SkillName { get => skillName; set => skillName = value; }
        public string Description { get => description; set => description = value; }

        public Skill(string skillName, string description)
        {
            SkillName = skillName;
            Description = description;
        }

        public Skill()
        {

        }
    }
}
