using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class UserRepo : IUserRepo
    {
        public UserRepo()
        {

        }
        UserDao userBase = new UserDao();

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

        public int AddUser(User user)
        {
            return userBase.AddUser(user);
        }
    }
}
