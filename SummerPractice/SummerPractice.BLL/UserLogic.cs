using SummerPractice.DAL;
using SummerPractice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.BLL
{
    public class UserLogic : IUserLogic
    {
        UserBase userBase = new UserBase();
        public string CreateUser(User user)
        {
            return userBase.CreateUser(user);
        }
    }
}
