using System;
using AppConfig;
using LogicContracts;
using Ninject;

namespace ConsoleUI
{
    internal class Program
    {
        private static ILogic logic;

        static Program()
        {
            IKernel kernel = new StandardKernel();
            DependencyConfig.RegisterServices(kernel);

            logic = kernel.Get<ILogic>();
        }
        
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                try
                {
                    Console.WriteLine("1. add person");
                    Console.WriteLine("2. add medal");
                    Console.WriteLine("3. delete person");
                    Console.WriteLine("4. delete medal");
                    Console.WriteLine("5. add medal to person");
                    Console.WriteLine("6. show all medals");
                    Console.WriteLine("7. show all person's medals");
                    Console.WriteLine("0. exit");

                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            AddPerson();
                            break;
                        case ConsoleKey.D2:
                            AddMedal();
                            break;
                        case ConsoleKey.D3:
                            DeletePerson();
                            break;
                        case ConsoleKey.D4:
                            DeleteMedal();
                            break;
                        case ConsoleKey.D5:
                            AddMedalToPerson();
                            break;
                        case ConsoleKey.D6:
                            ShowMedals();
                            break;
                        case ConsoleKey.D7:
                            ShowMedalsForPerson();
                            break;
                        case ConsoleKey.D0:
                            return;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }

        private static void AddPerson()
        {
            
        }

        private static void AddMedal()
        {
            
        }

        private static void DeletePerson()
        {
            
        }
        
        private static void DeleteMedal()
        {
            
        }

        private static void AddMedalToPerson()
        {
            
        }

        private static void ShowMedals()
        {
            
        }

        private static void ShowMedalsForPerson()
        {
            
        }
    }
}