using System;
using System.Configuration;
using DataAccessContracts;
using Logic;
using LogicContracts;
using MemoryDataAccess;
using MSSQLDataAccess;
using Ninject;

namespace AppConfig
{
    public class DependencyConfig
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel
                .Bind<ILogic>()
                .To<AppLogic>();

            switch (ConfigurationManager.AppSettings["DaoType"])
            {
                case "Memory":
                    kernel
                        .Bind<IDataAccess>()
                        .To<MemoryDao>();
                    break;
                case "DataBase":
                    kernel
                        .Bind<IDataAccess>()
                        .To<MSSQLDao>();
                    break;
                default:
                    throw new ArgumentException("Wrong DAO type in config file");
            }
        }
    }
}