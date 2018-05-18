using System;
using AppConfig;
using Entities;
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
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            
            Console.Write("Enter birth date: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            
            Console.Write("Enter age: ");
            if (int.TryParse(Console.ReadLine(), out var age))
            {
                throw new ArgumentException("incorrect age");
            }

            Person person = logic.SavePerson(firstName, lastName, birthDate, age);
        }

        private static void AddMedal()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            
            Console.WriteLine("Choose material:");
            ShowMaterials();
            
            if (int.TryParse(Console.ReadLine(), out var id) || logic.GetMaterialById(id) == null)
            {
                throw new ArgumentException("incorrect id");
            }

            Medal medal = logic.SaveMedal(name, logic.GetMaterialById(id));
        }

        private static void AddMedalToPerson()
        {
            Console.WriteLine("Choose medal:");
            ShowMedals();
            
            if (int.TryParse(Console.ReadLine(), out var medalId) || logic.GetMedalById(medalId) == null)
            {
                throw new ArgumentException("incorrect id");
            }
            
            Console.WriteLine("Choose person:");
            ShowPersons();
            
            if (int.TryParse(Console.ReadLine(), out var personId) || logic.GetPersonById(personId) == null)
            {
                throw new ArgumentException("incorrect id");
            }
            
            logic.AddMedalToPerson(logic.GetPersonById(personId), logic.GetMedalById(medalId));
        }

        private static void ShowPersons()
        {
            foreach (Person person in logic.GetAllPersons())
            {
                Console.WriteLine(person);
            }
        }
        
        private static void ShowMedals()
        {
            foreach (Medal medal in logic.GetAllMedals())
            {
                Console.WriteLine(medal);
            }
        }
        
        private static void ShowMaterials()
        {
            foreach (Material material in logic.GetAllMaterials())
            {
                Console.WriteLine(material);
            }
        }

        private static void ShowMedalsForPerson()
        {
            Console.WriteLine("Choose person:");
            ShowPersons();
            
            if (int.TryParse(Console.ReadLine(), out var id) || logic.GetPersonById(id) == null)
            {
                throw new ArgumentException("incorrect id");
            }
            
            foreach (Medal medal in logic.GetPersonMedals(id))
            {
                Console.WriteLine(medal);
            }
        }
        
        private static void DeletePerson()
        {
            Console.WriteLine("Choose person:");
            ShowPersons();
            
            if (int.TryParse(Console.ReadLine(), out var id) || logic.GetPersonById(id) == null)
            {
                throw new ArgumentException("incorrect id");
            }

            bool result = logic.DeletePerson(id);
        }
        
        private static void DeleteMedal()
        {
            Console.WriteLine("Choose medal:");
            ShowMedals();
            
            if (int.TryParse(Console.ReadLine(), out var id) || logic.GetMedalById(id) == null)
            {
                throw new ArgumentException("incorrect id");
            }

            bool result = logic.DeleteMedal(id);
        }
    }
}