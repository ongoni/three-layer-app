using System;
using System.Configuration;
using Logic;
using LogicContracts;
using DataAccessContracts;
using MemoryDataAccess;
using MSSQLDataAccess;
using Ninject;

namespace AppConfig
{
    public class AppConfig
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel
                .Bind<ILogicContract>()
                .To<AppLogic>();

            switch (ConfigurationManager.AppSettings["DaoType"])
            {
                case "Memory":
                    kernel
                        .Bind<IDataAccessContract>()
                        .To<MemoryDao>();
                    break;
                case "DataBase":
                    kernel
                        .Bind<IDataAccessContract>()
                        .To<MSSQLDao>();
                    break;
                default:
                    throw new ArgumentException("Wrong DAO type in config file");
            }
        }
    }
}