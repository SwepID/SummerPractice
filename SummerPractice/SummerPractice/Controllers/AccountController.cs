using BLL;
using Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SummerPractice.Controllers
{
    public class AccountController : Controller
    {
        ISkillRepo skillRepo;
        IUserRepo userRepo;
        IEncryption encryptionRepo;

        //DO TO move to ninject
        public AccountController(ISkillRepo skillRepository, IUserRepo userRepository, IEncryption encryptionRepository)
        {
            skillRepo = skillRepository;
            userRepo = userRepository;
            encryptionRepo = encryptionRepository;
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login loginEntity)
        {
            
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                User user = null;
                string hashPass = encryptionRepo.GetHash(loginEntity.Password);
                user = userRepo.GetAllUsers().FirstOrDefault(u => u.Login == loginEntity.Name && u.Password == hashPass);
                
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Login, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет!");
                }
            }

            return View(loginEntity);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register registerEntity)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                user = userRepo.GetAllUsers().FirstOrDefault(u => u.Login == registerEntity.Name);
                
                if (user == null)
                {
                    userRepo.AddUser(new User { Login = registerEntity.Name, Password = encryptionRepo.GetHash(registerEntity.Password), Fname = registerEntity.Fname, Sname = registerEntity.Sname });
                    string hashPass = encryptionRepo.GetHash(registerEntity.Password);
                    user = userRepo.GetAllUsers().Where(u => u.Login == registerEntity.Name && u.Password == hashPass).FirstOrDefault();
                    
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(registerEntity.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(registerEntity);
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
            User user = userRepo.GetUserByLogin(User.Identity.Name);
            user.SkillList = skillRepo.GetUserSkills(user);
            ViewData["user"] = user;
            return View(user);
        }
        public ActionResult FindSkillInProfile(string skillName)
        {
            User user = userRepo.GetUserByLogin(User.Identity.Name);
            user.SkillList = skillRepo.GetUserSkills(user).Where(el => el.SkillName == skillName);
            ViewData["user"] = user;
            return View("Profile", user);
        }
        public ActionResult SearchProfile()
        {
            string search = Request.Form["search"];
            ViewBag.Title = "Результаты поиска по запросу " + $"\"{search}\"";
            ViewData["User"] = userRepo.GetUserByLogin(search);
            return View();
        }
        [Authorize]
        public ActionResult UpdateForm(int skillId, int userId)
        {
            ViewData["userId"] = userId;
            ViewData["skillId"] = skillId;
            return View(new Skill());
        }
        [Authorize]
        [HttpPost]
        public ActionResult UpdateSkill(int skillId, string skillName, string Description)
        {
            User user = userRepo.GetUserByLogin(User.Identity.Name);
            IEnumerable<Skill> skillCollection = skillRepo.GetUserSkills(user);
            if (skillCollection.Where(element => element.Id == skillId).Count() != 0)
            {
                skillRepo.UpdateSkill(skillId, skillName, Description);
            }
            return RedirectToAction("Profile");
        }
        [Authorize]
        public ActionResult AddForm(int userId, Skill skill)
        {
            ViewData["userId"] = userId;

            return View(skill);
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddSkill(string skillName, string Description, int userId)
        {
            User user = userRepo.GetUserById(userId);
            Skill skill = new Skill() { SkillName = skillName, Description = Description };
            skillRepo.AddSkillToUser(skill, user);
            return RedirectToAction("Profile");
        }
        [Authorize]
        public ActionResult RemoveSkill(int skillId)
        {
            User user = userRepo.GetUserByLogin(User.Identity.Name);
            ViewBag.Title = "Навыки";
            IEnumerable<Skill> skillCollection = skillRepo.GetUserSkills(user);
            if (skillCollection.Where(element => element.Id == skillId).Count() != 0)
            {
                skillRepo.RemoveSkill(skillId);
                skillCollection = skillCollection.Where(element => element.Id != skillId);
            }
            return RedirectToAction("Profile");
        }
        [Authorize]
        public ActionResult EditAccountInfo(int userId, User user)
        {
            ViewData["userId"] = userId;
            System.Diagnostics.Debug.WriteLine(userId);
            return View(user);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditAccountInfo(int userId, string fname, string sname)
        {
            User user = userRepo.GetUserByLogin(User.Identity.Name);
            if (userId == user.Id)
            {
                userRepo.EditUserInfo(userId, fname, sname);
            }

        return RedirectToAction("Profile");
        }
        public ActionResult ChangePassForm(int userId)
        {
            ViewData["userId"] = userId;
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassForm(ChangePass changePassEntity, int userId)
        {
            User user = userRepo.GetUserByLogin(User.Identity.Name);
            if (ModelState.IsValid)
            {
                if (userId == user.Id)
                {
                    if (user.Password == encryptionRepo.GetHash(changePassEntity.OldPassword))
                    {
                        userRepo.ChangePassword(user.Id, encryptionRepo.GetHash(changePassEntity.Password));
                        ViewBag.Message = "Пароль успешно изменен!";
                        return RedirectToAction("Profile");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неверно указан старый пароль!");
                    }
                }
            }
            return View(changePassEntity);
        }
    }
}