using SummerPractice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.DAL
{
    interface ISkillBase
    {
        string AddSkill(Skill skill);
        string RemoveSkill(string skillName);
        string UpdateSkillDescription(string skillName, string newDiscription);
        string UpdateSkillName(string oldName, string newName);
        IEnumerable<Skill> GetSkill(string skillName);
        IEnumerable<SummerPractice.Entities.Skill> GetAllSkills();
    }
}
