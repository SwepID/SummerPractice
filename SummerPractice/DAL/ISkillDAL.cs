using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface ISkillDAL
    {
        int AddSkill(Skill skill);
        string RemoveSkill(int skillId);
        string UpdateSkillDescription(string skillName, string newDescription);
        string UpdateSkillName(string oldName, string newName);
        Skill GetSkill(int skillId);
        IEnumerable<Skill> GetSkill(string skillName);
        IEnumerable<Skill> GetAllSkills();
        IEnumerable<Skill> SortByName();
        string AddSkillToUser(Skill skill, User user);
    }
}
