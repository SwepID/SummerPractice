using BLL;
using Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SummerPractice.Controllers
{
    public class SkillController : System.Web.Mvc.Controller
    {
        ISkillRepo skillRepo;
        IUserRepo userRepo;
        IEncryption encryptionRepo;

        //DO TO move to ninject
        public SkillController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IUserRepo>().To<UserRepo>();
            ninjectKernel.Bind<ISkillRepo>().To<SkillRepo>();
            ninjectKernel.Bind<IEncryption>().To<Encryption>();
            skillRepo = ninjectKernel.Get<ISkillRepo>();
            userRepo = ninjectKernel.Get<IUserRepo>();
            encryptionRepo = ninjectKernel.Get<IEncryption>();
        }

        public ViewResult List()
        {
            ViewBag.Title = "Skills";
            IEnumerable<Skill> skillCollection = skillRepo.GetAllSkills();
            ViewData["Skills"] = skillCollection;
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(string skillName, string description)
        {
            ViewBag.Title = "Список навыков";
            IEnumerable<Skill> skillCollection = skillRepo.GetAllSkills();
            if (ModelState.IsValid)
            {
                if (skillCollection.Count() != 0)
                {
                    var skillId = skillCollection.Max(Skill => Skill.Id) + 1;
                    skillCollection.Append(new Skill() { Id = skillId, SkillName = skillName, Description = description });
                }
                else
                {
                    skillCollection.Append(new Skill() { Id = 1, SkillName = skillName, Description = description });
                }
                skillRepo.AddSkill(new Skill() { SkillName = skillName, Description = description });
                return RedirectToAction("List");
            }
            ViewData.Add(new KeyValuePair<string, object>("Навыки", skillCollection));
            return View("List");
        }
        public ActionResult RemoveSkill(int skillId)
        {
            ViewBag.Title = "Навыки";
            skillRepo.RemoveSkill(skillId);
            return RedirectToAction("List");
        }
        public ActionResult UpdateSkillName()
        {

            return RedirectToAction("List");
        }
        public ActionResult SortByName()
        {
            ViewBag.Title = "Список отсортированных навыков";
            IEnumerable<Skill> skillCollection = skillRepo.SortByName();
            ViewData["Skills"] = skillCollection;
            return View("List");
        }
        public ActionResult FindSkill()
        {
            string search = Request.Form["search"];
            ViewBag.Title = "Результаты поиска по запросу " + $"\"{search}\"";
            ViewData["SearchResults"] = skillRepo.GetSkill(search);    
            return View("SearchResults");
        }
    }
}