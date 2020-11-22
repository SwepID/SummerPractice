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
        IUserDAL userDAL;
        public UserRepo(IUserDAL userD)
        {
            userDAL = userD;
        }

        public User GetUserByLogin(string login)
        {
            return userDAL.GetUserByLogin(login);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }
        public User GetUserById(int idUser)
        {
            return userDAL.GetUserById(idUser);
        }
        public string EditUserInfo(int idUser, string fname, string sname)
        {
            return userDAL.EditUserInfo(idUser, fname, sname);
        }
        public string ChangePassword(int idUser, string password)
        {
            return userDAL.ChangePassword(idUser, password);
        }

        public int AddUser(User user)
        {
            return userDAL.AddUser(user);
        }
    }
}
