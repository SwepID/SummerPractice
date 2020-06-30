using SummerPractice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.BLL
{
    interface IUserLogic
    {
        string CreateUser(string login, string password);
        string DeleteUser(string login);
        IEnumerable<User> GetAllUsers();
        string AddSkillToUser(string skillName, string login);
    }
}
