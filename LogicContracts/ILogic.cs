using System;
using System.Collections.Generic;
using Entities;

namespace LogicContracts
{
    public interface ILogic
    {
        List<Person> GetAllPersons();
        List<Medal> GetAllMedals();
        List<Address> GetAllAddresses();
        List<Material> GetAllMaterials();
        Person GetPersonById(int id);
        Medal GetMedalById(int id);
        Address GetAddressById(int id);
        Material GetMaterialById(int id);
        List<Medal> GetPersonMedals(int id);
        Person SavePerson(string firstName, string lastName, DateTime birthDate, int age);
        Person SavePerson(string firstName, string lastName, DateTime birthDate, int age, List<Address> addresses);
        Person SavePerson(string firstName, string lastName, DateTime birthDate, int age, List<Address> addresses, 
            List<Medal> medals);
        Medal SaveMedal(string name, Material material);
        Address SaveAddress(string city, string street, string houseNumber);
        Material SaveMaterial(string name);
        void AddMedalToPerson(Person person, Medal medal);
        bool DeletePerson(int id);
        bool DeleteMedal(int id);
        bool DeleteAddress(int id);
        bool DeleteMaterial(int id);
    }
}