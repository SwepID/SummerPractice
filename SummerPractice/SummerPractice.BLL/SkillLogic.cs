using SummerPractice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.BLL
{
    class SkillLogic : ISkillLogic
    {
        SummerPractice.DAL.SkillBase skillBase = new DAL.SkillBase();
        public string AddSkill(string skillName, string description)
        {
            throw new NotImplementedException();
        }

        public string DeleteSkill(string skillName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            throw new NotImplementedException();
        }

        public Skill GetSkill(string skillName)
        {
            throw new NotImplementedException();
        }

        public string UpdateSkillDescription(string skillName, string newDiscription)
        {
            throw new NotImplementedException();
        }

        public string UpdateSkillName(string oldName, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
