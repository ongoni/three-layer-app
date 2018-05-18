using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessContracts;
using Entities;

namespace MemoryDataAccess
{
    public class MemoryDao : IDataAccess
    {
        private readonly HashSet<Person> _persons;
        private readonly HashSet<Medal> _medals;
        private readonly HashSet<Address> _addresses;
        private readonly HashSet<Material> _materials;

        private int _maxPersonId;
        private int _maxMedalId;
        private int _maxAddressId;
        private int _maxMaterialId;
        
        public MemoryDao()
        {
            _persons = new HashSet<Person>();
            _medals = new HashSet<Medal>();
            _addresses = new HashSet<Address>();
            _materials = new HashSet<Material>();
            _maxPersonId = 0;
            _maxMedalId = 0;
            _maxAddressId = 0;
            _maxMaterialId = 0;
        }
        
        public bool Add(Person person)
        {
            person.Id = ++_maxPersonId;
            _persons.Add(person);

            if (person.Addresses.Count != 0)
            {
                foreach (Address address in person.Addresses)
                {
                    if (!_addresses.Contains(address))
                    {
                        Add(address);
                    }
                }
            }
            
            if (person.Medals.Count != 0)
            {
                foreach (Medal medal in person.Medals)
                {
                    if (!_medals.Contains(medal))
                    {
                        Add(medal);
                    }
                }
            }

            return true;
        }

        public bool Add(Medal medal)
        {
            medal.Id = ++_maxMedalId;
            _medals.Add(medal);

            if (medal.Material != null && !_materials.Contains(medal.Material))
            {
                _materials.Add(medal.Material);
            }
            
            return true;
        }

        public bool Add(Address address)
        {
            address.Id = ++_maxAddressId;
            _addresses.Add(address);

            return true;
        }

        public bool Add(Material material)
        {
            material.Id = ++_maxMaterialId;
            _materials.Add(material);

            return true;
        }

        public void AddMedalToPerson(Person person, Medal medal)
        {
            if (!_persons.Contains(person))
            {
                _persons.Add(person);
            }
            
            person.Medals.Add(medal);

            if (!_medals.Contains(medal))
            {
                _medals.Add(medal);
            }
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _persons.Select(x => x);
        }

        public IEnumerable<Medal> GetAllMedals()
        {
            return _medals.Select(x => x);
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            return _addresses.Select(x => x);
        }

        public IEnumerable<Material> GetAllMaterials()
        {
            return _materials.Select(x => x);
        }

        public IEnumerable<Medal> GetPersonMedalsByPersonId(int id)
        {
            return _persons
                .FirstOrDefault(x => x.Id == id)?
                .Medals
                .Select(x => x);
        }

        public IEnumerable<Address> GetPersonAddressesByPersonId(int id)
        {
            return _persons
                .FirstOrDefault(x => x.Id == id)?
                .Addresses
                .Select(x => x);
        }

        public Person GetPersonById(int id)
        {
            return _persons.FirstOrDefault(x => x.Id == id);
        }

        public Medal GetMedalById(int id)
        {
            return _medals.FirstOrDefault(x => x.Id == id);
        }

        public Address GetAddressById(int id)
        {
            return _addresses.FirstOrDefault(x => x.Id == id);
        }

        public Material GetMaterialById(int id)
        {
            return _materials.FirstOrDefault(x => x.Id == id);
        }

        public bool DeletePersonById(int id)
        {
            Person person = _persons.FirstOrDefault(x => x.Id == id);
            
            if (person == null)
            {
                return false;
            }

            return _persons.Remove(person);
        }

        public bool DeleteMedalById(int id)
        {
            Medal medal = _medals.FirstOrDefault(x => x.Id == id);
            
            if (medal == null)
            {
                return false;
            }

            return _medals.Remove(medal);
        }

        public bool DeleteAddressById(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMaterialById(int id)
        {
            throw new NotImplementedException();
        }
    }
}