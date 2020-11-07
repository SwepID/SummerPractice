using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SkillRepo : ISkillRepo
    {
        public SkillRepo()
        {

        }

        DAL.SkillDao skillDao = new DAL.SkillDao();
        public int AddSkill(Skill skill)
        {
            return skillDao.AddSkill(skill);
        }
        public string AddSkillToUser(Skill skill, User user)
        {
            return skillDao.AddSkillToUser(skill, user);
        }

        public string RemoveSkill(int skillId)
        {
            return skillDao.RemoveSkill(skillId);
        }
        public string RemoveSkillFromUser(int skillId, int userId)
        {
            return skillDao.RemoveSkillFromUser(skillId, userId);
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return skillDao.GetAllSkills();
        }
        public IEnumerable<Skill> GetUserSkills(User user)
        {
            return skillDao.GetUserSkills(user);
        }

        public Skill GetSkill(int skillId)
        {
            return skillDao.GetSkill(skillId);
        }
        public IEnumerable<Skill> GetSkill(string skillName)
        {
            return skillDao.GetSkill(skillName);
        }

        public string UpdateSkillDescription(string skillName, string newDiscription)
        {
            return skillDao.UpdateSkillDescription(skillName, newDiscription);
        }
        public string UpdateSkill(int skillId, string skillName, string description)
        {
            return skillDao.UpdateSkill(skillId, skillName, description);
        }

        public string UpdateSkillName(string oldName, string newName)
        {
            return skillDao.UpdateSkillName(oldName, newName);
        }
        public IEnumerable<Skill> SortByName()
        {
            return skillDao.SortByName();
        }
    }
}

