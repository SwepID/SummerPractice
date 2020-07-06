using SummerPractice.Models;
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
        string RemoveSkill(int skillId);
        string UpdateSkillDescription(string skillName, string newDescription);
        string UpdateSkillName(string oldName, string newName);
        IEnumerable<Skill> GetSkill(string skillName);
        IEnumerable<Skill> GetAllSkills();
        IEnumerable<Skill> SortByName();
    }
}
