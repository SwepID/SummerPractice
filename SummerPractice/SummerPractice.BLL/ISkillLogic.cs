using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.BLL
{
    interface ISkillLogic
    {
        string AddSkill(string skillName, string description);
        string DeleteSkill(string skillName);
        string UpdateSkillDescription(string skillName, string newDiscription);
        string UpdateSkillName(string oldName, string newName);
        SummerPractice.Entities.Skill GetSkill(string skillName);
        IEnumerable<SummerPractice.Entities.Skill> GetAllSkills();
    }
}
