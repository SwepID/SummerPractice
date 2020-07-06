using SummerPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SummerPractice.Controllers
{
    public class SkillController : System.Web.Mvc.Controller
    {
        public static class Solution
        {
            public static string result = "";
            public static IEnumerable<Skill> skillCollection = new SkillModel().GetAllSkills();
        }
        public ViewResult List()
        {
            ViewBag.Title = "Skills";
            ViewData["Result"] = Solution.result;
            Solution.skillCollection = new SkillModel().GetAllSkills();
            ViewData["Skills"] = Solution.skillCollection;
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(string skillName, string description)
        {
            ViewBag.Title = "Список навыков";
            SkillModel skillModel = new SkillModel();
            if (ModelState.IsValid)
            {
                if (Solution.skillCollection.Count() != 0)
                {
                    var skillId = Solution.skillCollection.Max(Skill => Skill.Id) + 1;
                    Solution.skillCollection.Append(new Skill() { Id = skillId, SkillName = skillName, Description = description });
                }
                else
                {
                    Solution.skillCollection.Append(new Skill() { Id = 1, SkillName = skillName, Description = description });
                }
                skillModel.AddSkill(new Skill() { SkillName = skillName, Description = description });
                return RedirectToAction("List");
            }
            ViewData.Add(new KeyValuePair<string, object>("Навыки", Solution.skillCollection));
            return View("List");
        }
        public ActionResult RemoveSkill(int skillId)
        {
            ViewBag.Title = "Навыки";
            SkillModel skillModel = new SkillModel();
            Solution.skillCollection = Solution.skillCollection.Where(element => element.Id != skillId);
            Solution.result = skillModel.RemoveSkill(skillId);
            return RedirectToAction("List");
        }
        public ActionResult UpdateSkillName()
        {

            return RedirectToAction("List");
        }
        public ActionResult SortByName()
        {
            SkillModel skillModel = new SkillModel();
            ViewBag.Title = "Список отсортированных навыков";
            Solution.skillCollection = skillModel.SortByName();
            ViewData["Skills"] = Solution.skillCollection;
            return View("List");
        }
        public ActionResult FindSkill()
        {
            string search = Request.Form["search"];
            ViewBag.Title = "Результаты поиска по запросу " + $"\"{search}\"";
            SkillModel skillModel = new SkillModel();
            ViewData["SearchResults"] = skillModel.GetSkill(search);    
            return View("SearchResults");
        }

    }
}