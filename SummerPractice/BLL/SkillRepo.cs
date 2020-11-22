using DAL;
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
        ISkillDAL skillRepository;
        public SkillRepo(ISkillDAL skillRepo)
        {
            skillRepository = skillRepo;
        }

        public int AddSkill(Skill skill)
        {
            return skillRepository.AddSkill(skill);
        }
        public string AddSkillToUser(Skill skill, User user)
        {
            return skillRepository.AddSkillToUser(skill, user);
        }

        public string RemoveSkill(int skillId)
        {
            return skillRepository.RemoveSkill(skillId);
        }
        public string RemoveSkillFromUser(int skillId, int userId)
        {
            return skillRepository.RemoveSkillFromUser(skillId, userId);
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return skillRepository.GetAllSkills();
        }
        public IEnumerable<Skill> GetUserSkills(User user)
        {
            return skillRepository.GetUserSkills(user);
        }

        public Skill GetSkill(int skillId)
        {
            return skillRepository.GetSkill(skillId);
        }
        public IEnumerable<Skill> GetSkill(string skillName)
        {
            return skillRepository.GetSkill(skillName);
        }

        public string UpdateSkillDescription(string skillName, string newDiscription)
        {
            return skillRepository.UpdateSkillDescription(skillName, newDiscription);
        }
        public string UpdateSkill(int skillId, string skillName, string description)
        {
            return skillRepository.UpdateSkill(skillId, skillName, description);
        }

        public string UpdateSkillName(string oldName, string newName)
        {
            return skillRepository.UpdateSkillName(oldName, newName);
        }
        public IEnumerable<Skill> SortByName()
        {
            return skillRepository.SortByName();
        }
    }
}

