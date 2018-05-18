using System.Collections.Generic;
using Entities;

namespace DataAccessContracts
{
    public interface IDataAccess
    {
        bool Add(Person person);
        bool Add(Medal medal);
        bool Add(Material material);
        bool Add(Address address);
        void AddMedalToPerson(Person person, Medal medal);
        IEnumerable<Person> GetAllPersons();
        IEnumerable<Medal> GetAllMedals();
        IEnumerable<Address> GetAllAddresses();
        IEnumerable<Material> GetAllMaterials();
        IEnumerable<Medal> GetPersonMedalsByPersonId(int id);
        IEnumerable<Address> GetPersonAddressesByPersonId(int id);
        Person GetPersonById(int id);
        Medal GetMedalById(int id);
        Address GetAddressById(int id);
        Material GetMaterialById(int id);
        bool DeletePersonById(int id);
        bool DeleteMedalById(int id);
        bool DeleteAddressById(int id);
        bool DeleteMaterialById(int id);
    }
}