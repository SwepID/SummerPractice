﻿using SummerPractice.Models;
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
        public string AddSkill(Skill skill)
        {
            return skillBase.AddSkill(skill);
        }

        public string RemoveSkill(int skillId)
        {
            return skillBase.RemoveSkill(skillId);
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
        public IEnumerable<Skill> SortByName()
        {
            return skillBase.SortByName();
        }
    }
}