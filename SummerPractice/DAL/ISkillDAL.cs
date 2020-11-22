using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISkillDAL
    {
        int AddSkill(Skill skill);
        string RemoveSkill(int skillId);
        string RemoveSkillFromUser(int skillId, int userId);
        string UpdateSkillDescription(string skillName, string newDescription);
        string UpdateSkillName(string oldName, string newName);
        string UpdateSkill(int skillId, string skillName, string description);
        Skill GetSkill(int skillId);
        IEnumerable<Skill> GetUserSkills(User user);
        IEnumerable<Skill> GetSkill(string skillName);
        IEnumerable<Skill> GetAllSkills();
        IEnumerable<Skill> SortByName();
        string AddSkillToUser(Skill skill, User user);
    }
}
