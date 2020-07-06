using SummerPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.DAL
{
    interface IUserBase
    {
        string CreateUser(User user);
    }
}
