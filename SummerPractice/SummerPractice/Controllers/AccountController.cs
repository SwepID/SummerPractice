using SummerPractice.Models;
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
                    user = db.Users.FirstOrDefault(u => u.Login == model.Name && u.Password == model.Password);

                }
                if (user != null)
                {
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
                        db.Users.Add(new User { Login = model.Name, Password = model.Password, Fname = model.Fname, Sname = model.Sname });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Login == model.Name && u.Password == model.Password).FirstOrDefault();
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
            user.SkillList = new SkillModel().GetAllSkills();
            ViewData["user"] = user;
            return View(user);
        }
        public ActionResult SearchProfile()
        {
            string search = Request.Form["search"];
            ViewBag.Title = "Результаты поиска по запросу " + $"\"{search}\"";
            ViewData["User"] = new UserModel().GetUserByLogin(search);
            return View();
        }
    }
}