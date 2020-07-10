using SummerPractice.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummerPractice.Models
{
    public class UserModel : User
    {
        public UserModel(string login, string password, string fname, string sname, int id, IEnumerable<Skill> skills) : base(login, fname, sname, password, skills)
        {

        }
        public UserModel()
        {

        }
        UserBase userBase = new UserBase();

        public User GetUserByLogin(string login)
        {
            return userBase.GetUserByLogin(login);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return userBase.GetAllUsers();
        }
        public User GetUserById(int idUser)
        {
            return userBase.GetUserById(idUser);
        }
        public string EditUserInfo(int idUser, string fname, string sname)
        {
            return userBase.EditUserInfo(idUser, fname, sname);
        }
        public string ChangePassword(int idUser, string password)
        {
            return userBase.ChangePassword(idUser, password);
        }
    }
}