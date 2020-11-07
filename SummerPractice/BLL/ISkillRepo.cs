using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ISkillRepo : IRepository
    {
        int AddSkill(Skill skill);
        string AddSkillToUser(Skill skill, User user);

        string RemoveSkill(int skillId);
        string RemoveSkillFromUser(int skillId, int userId);

        IEnumerable<Skill> GetAllSkills();
        IEnumerable<Skill> GetUserSkills(User user);

        Skill GetSkill(int skillId);
        IEnumerable<Skill> GetSkill(string skillName);

        string UpdateSkillDescription(string skillName, string newDiscription);
        string UpdateSkill(int skillId, string skillName, string description);

        string UpdateSkillName(string oldName, string newName);
        IEnumerable<Skill> SortByName();
    }
}
