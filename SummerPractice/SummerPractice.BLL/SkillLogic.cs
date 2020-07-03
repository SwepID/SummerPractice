using SummerPractice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.BLL
{
    public class SkillLogic : ISkillLogic
    {
        SummerPractice.DAL.SkillBase skillBase = new DAL.SkillBase();
        public string AddSkill(Skill skill)
        {
            return skillBase.AddSkill(skill);
        }

        public string RemoveSkill(string skillName)
        {
            return skillBase.RemoveSkill(skillName);
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return skillBase.GetAllSkills();
        }

        public IEnumerable<Skill> GetSkill(string skillName)
        {
            return skillBase.GetSkill(skillName);
        }

        public string UpdateSkillDescription(string skillName, string newDiscription)
        {
            return skillBase.UpdateSkillDescription(skillName, newDiscription);
        }

        public string UpdateSkillName(string oldName, string newName)
        {
            return skillBase.UpdateSkillName(oldName, newName);
        }
    }
}
