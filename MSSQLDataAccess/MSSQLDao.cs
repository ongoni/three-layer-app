using System.Collections.Generic;
using DataAccessContracts;
using Entities;

namespace MSSQLDataAccess
{
    public class MssqlDao : IDataAccess
    {
        public bool Add(Person person)
        {
            throw new System.NotImplementedException();
        }

        public bool Add(Medal medal)
        {
            throw new System.NotImplementedException();
        }

        public bool Add(Material material)
        {
            throw new System.NotImplementedException();
        }

        public bool Add(Address address)
        {
            throw new System.NotImplementedException();
        }

        public void AddMedalToPerson(Person person, Medal medal)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Medal> GetAllMedals()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Material> GetAllMaterials()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Medal> GetPersonMedalsByPersonId(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Address> GetPersonAddressesByPersonId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Person GetPersonById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Medal GetMedalById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Address GetAddressById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Material GetMaterialById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePersonById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteMedalById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteAddressById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteMaterialById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}