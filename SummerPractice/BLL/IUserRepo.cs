using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IUserRepo : IRepository
    {
        User GetUserByLogin(string login);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int idUser);
        string EditUserInfo(int idUser, string fname, string sname);
        string ChangePassword(int idUser, string password);
        int AddUser(User user);
    }
}
