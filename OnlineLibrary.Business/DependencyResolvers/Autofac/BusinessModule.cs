﻿using Autofac;
using OnlineLibrary.Business.Abstract;
using OnlineLibrary.Business.Concrete.Managers;
using OnlineLibrary.Core.Utilities.Security.JWT;
using OnlineLibrary.DataAccess.Abstract;
using OnlineLibrary.DataAccess.Concrete.EntityFramework;

namespace OnlineLibrary.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<UserBookManager>().As<IUserBookService>();
            builder.RegisterType<EfUserBookDal>().As<IUserBookDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
