using SummerPractice.DAL;
using SummerPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SummerPractice.Controllers
{
    public static class Solution
    {
        public static string result = "";
        public static IEnumerable<Skill> skillCollection = new SkillModel().GetAllSkills();
    }
    public class AccountController : Controller
    {

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                User user = null;
                using (Context db = new Context())
                {
                    string hashPass = SummerPractice.Encryption.Encryption.GetHash(model.Password);
                    user = db.Users.FirstOrDefault(u => u.Login == model.Name && u.Password == hashPass);
                }
                if (user != null)
                {
                    Solution.skillCollection = new SkillModel().GetUserSkills(user);
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (Context db = new Context())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == model.Name);
                }
                if (user == null)
                {
                    // создаем нового пользователя
                    using (Context db = new Context())
                    {
                        db.Users.Add(new User { Login = model.Name, Password = SummerPractice.Encryption.Encryption.GetHash(model.Password), Fname = model.Fname, Sname = model.Sname });
                        db.SaveChanges();
                        string hashPass = SummerPractice.Encryption.Encryption.GetHash(model.Password);
                        user = db.Users.Where(u => u.Login == model.Name && u.Password == hashPass).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Authorize]
        public ActionResult Profile()
        {
            User user = new UserModel().GetUserByLogin(User.Identity.Name);
            user.SkillList = new SkillModel().GetUserSkills(user);
            ViewData["user"] = user;
            return View(user);
        }
        public ActionResult FindSkillInProfile(string skillName)
        {
            User user = new UserModel().GetUserByLogin(User.Identity.Name);
            user.SkillList = new SkillModel().GetUserSkills(user).Where(el => el.SkillName == skillName);
            ViewData["user"] = user;
            return View("Profile", user);
        }
        public ActionResult SearchProfile()
        {
            string search = Request.Form["search"];
            ViewBag.Title = "Результаты поиска по запросу " + $"\"{search}\"";
            ViewData["User"] = new UserModel().GetUserByLogin(search);
            return View();
        }
        [Authorize]
        public ActionResult UpdateForm(int skillId, int userId, SkillModel skillModel)
        {
            ViewData["userId"] = userId;
            ViewData["skillId"] = skillId;
            return View(skillModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult UpdateSkill(int skillId, string skillName, string Description)
        {
            User user = new UserModel().GetUserByLogin(User.Identity.Name);
            SkillModel skillModel = new SkillModel();
            Solution.skillCollection = skillModel.GetUserSkills(user);
            if (Solution.skillCollection.Where(element => element.Id == skillId).Count() != 0)
            {
                skillModel.UpdateSkill(skillId, skillName, Description);
            }
            return RedirectToAction("Profile");
        }
        [Authorize]
        public ActionResult AddForm(int userId, SkillModel skillModel)
        {
            ViewData["userId"] = userId;

            return View(skillModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddSkill(string skillName, string Description, int userId)
        {
            User user = new UserModel().GetUserById(userId);
            Skill skill = new Skill() { SkillName = skillName, Description = Description };
            new SkillModel().AddSkillToUser(skill, user);
            return RedirectToAction("Profile");
        }
        [Authorize]
        public ActionResult RemoveSkill(int skillId)
        {
            User user = new UserModel().GetUserByLogin(User.Identity.Name);
            ViewBag.Title = "Навыки";
            SkillModel skillModel = new SkillModel();
            Solution.skillCollection = skillModel.GetUserSkills(user);
            if (Solution.skillCollection.Where(element => element.Id == skillId).Count() != 0)
            {
                skillModel.RemoveSkill(skillId);
                Solution.skillCollection = Solution.skillCollection.Where(element => element.Id != skillId);
            }
            return RedirectToAction("Profile");
        }

    }
}