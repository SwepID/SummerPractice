using BLL;
using DAL;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ISkillRepo>().To<SkillRepo>();
            Bind<IUserRepo>().To<UserRepo>();
            Bind<IEncryption>().To<Encryption>();
            Bind<IUserDAL>().To<UserDao>();
            Bind<ISkillDAL>().To<SkillDao>();
        }
    }
}