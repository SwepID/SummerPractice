using SummerPractice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            SummerPractice.BLL.UserLogic userLogic = new BLL.UserLogic();
            SummerPractice.BLL.SkillLogic skillLogic = new BLL.SkillLogic();
            Console.WriteLine(skillLogic.AddSkill(new Skill() { SkillName = "скилл", Description = "описание" }));
        }
    }
}
