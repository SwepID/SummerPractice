using SummerPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.Models
{
    public class SkillModel : Skill
    {
        public string SkillName { get; set; }
        public string Description { get; set; }
        public SkillModel(int id, string skillName, string description, IEnumerable<User> users) : base(id, skillName, description, users )
        {

        }

        public SkillModel()
        {

        }

        SummerPractice.DAL.SkillBase skillBase = new DAL.SkillBase();
        public int AddSkill(Skill skill)
        {
            return skillBase.AddSkill(skill);
        }
        public string AddSkillToUser(Skill skill, User user)
        {
            return skillBase.AddSkillToUser(skill, user);
        }

        public string RemoveSkill(int skillId)
        {
            return skillBase.RemoveSkill(skillId);
        }
        public string RemoveSkillFromUser(int skillId, int userId)
        {
            return skillBase.RemoveSkillFromUser(skillId, userId);
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return skillBase.GetAllSkills();
        }
        public IEnumerable<Skill> GetUserSkills(User user)
        {
            return skillBase.GetUserSkills(user);
        }

        public Skill GetSkill(int skillId)
        {
            return skillBase.GetSkill(skillId);
        }
        public IEnumerable<Skill> GetSkill(string skillName)
        {
            return skillBase.GetSkill(skillName);
        }

        public string UpdateSkillDescription(string skillName, string newDiscription)
        {
            return skillBase.UpdateSkillDescription(skillName, newDiscription);
        }
        public string UpdateSkill(int skillId, string skillName, string description)
        {
            return skillBase.UpdateSkill(skillId, skillName, description);
        }

        public string UpdateSkillName(string oldName, string newName)
        {
            return skillBase.UpdateSkillName(oldName, newName);
        }
        public IEnumerable<Skill> SortByName()
        {
            return skillBase.SortByName();
        }
    }
}
