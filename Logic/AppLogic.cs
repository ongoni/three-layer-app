using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessContracts;
using Entities;
using LogicContracts;

namespace Logic
{
    public class AppLogic : ILogic
    {
        private IDataAccess _dataAccess;

        public AppLogic(IDataAccess dao)
        {
            _dataAccess = dao;
        }

        public List<Person> GetAllPersons()
        {
            return _dataAccess.GetAllPersons().ToList();
        }

        public List<Medal> GetAllMedals()
        {
            return _dataAccess.GetAllMedals().ToList();
        }

        public List<Address> GetAllAddresses()
        {
            return _dataAccess.GetAllAddresses().ToList();
        }

        public List<Material> GetAllMaterials()
        {
            return _dataAccess.GetAllMaterials().ToList();
        }

        public Person GetPersonById(int id)
        {
            return _dataAccess.GetPersonById(id);
        }

        public Medal GetMedalById(int id)
        {
            return _dataAccess.GetMedalById(id);
        }

        public Material GetMaterialById(int id)
        {
            return _dataAccess.GetMaterialById(id);
        }

        public List<Medal> GetPersonMedals(int id)
        {
            return _dataAccess.GetPersonMedalsByPersonId(id).ToList();
        }

        public Address GetAddressById(int id)
        {
            return _dataAccess.GetAddressById(id);
        }

        public Person SavePerson(string firstName, string lastName, DateTime birthDate, int age)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || age <= 0)
            {
                throw new ArgumentException("person's data are incorrect");
            }

            Person person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                Age = age,
                Addresses = new List<Address>(),
                Medals = new List<Medal>()
            };

            if (_dataAccess.Add(person))
            {
                return person;
            }
            else
            {
                throw new InvalidOperationException("error during person saving");
            }
        }

        public Person SavePerson(string firstName, string lastName, DateTime birthDate, int age, List<Address> addresses)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || age <= 0 || addresses == null)
            {
                throw new ArgumentException("person's data are incorrect");
            }

            Person person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                Age = age,
                Addresses = addresses,
                Medals = new List<Medal>()
            };

            if (_dataAccess.Add(person))
            {
                return person;
            }
            else
            {
                throw new InvalidOperationException("error during person saving");
            }
        }

        public Person SavePerson(string firstName, string lastName, DateTime birthDate, int age, List<Address> addresses,
            List<Medal> medals)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || age <= 0 
                || addresses == null || medals == null)
            {
                throw new ArgumentException("person's data are incorrect");
            }

            Person person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                Age = age,
                Addresses = addresses,
                Medals = medals
            };

            if (_dataAccess.Add(person))
            {
                return person;
            }
            else
            {
                throw new InvalidOperationException("error during person saving");
            }
        }
        
        public Medal SaveMedal(string name, Material material)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("medal's data are incorrect");
            }

            Medal medal = new Medal
            {
                Name = name,
                Material = material
            };
            
            if (_dataAccess.Add(medal))
            {
                return medal;
            }
            else
            {
                throw new InvalidOperationException("error during medal saving");
            }
        }

        public Address SaveAddress(string city, string street, string houseNumber)
        {
            if (string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(houseNumber))
            {
                throw new ArgumentException("address' data are incorrect");
            }

            Address address = new Address()
            {
                City = city,
                Street = street,
                HouseNumber = houseNumber
            };
            
            if (_dataAccess.Add(address))
            {
                return address;
            }
            else
            {
                throw new InvalidOperationException("error during address saving");
            }
        }

        public Material SaveMaterial(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("material's data are incorrect");
            }

            Material material = new Material()
            {
                Name = name
            };
            
            if (_dataAccess.Add(material))
            {
                return material;
            }
            else
            {
                throw new InvalidOperationException("error during material saving");
            }
        }

        public void AddMedalToPerson(Person person, Medal medal)
        {
            _dataAccess.AddMedalToPerson(person, medal);
        }

        public bool DeletePerson(int id)
        {
            if (!GetAllPersons().Any(x => x.Id == id))
            {
                throw new ArgumentException($"person with id = {id} not found");
            }

            return _dataAccess.DeletePersonById(id);
        }

        public bool DeleteMedal(int id)
        {
            if (!GetAllMedals().Any(x => x.Id == id))
            {
                throw new ArgumentException($"medal with id = {id} not found");
            }

            return _dataAccess.DeleteMedalById(id);
        }

        public bool DeleteAddress(int id)
        {
            if (!GetAllAddresses().Any(x => x.Id == id))
            {
                throw new ArgumentException($"address with id = {id} not found");
            }

            return _dataAccess.DeleteAddressById(id);
        }

        public bool DeleteMaterial(int id)
        {
            if (!GetAllMaterials().Any(x => x.Id == id))
            {
                throw new ArgumentException($"material with id = {id} not found");
            }

            return _dataAccess.DeleteMaterialById(id);
        }
    }
}