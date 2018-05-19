using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using DataAccessContracts;
using Entities;

namespace MSSQLDataAccess
{
    public class MssqlDao : IDataAccess
    {
        private string _connectionString;

        public MssqlDao()
        {
            _connectionString = getConnectionString();
        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Rewards"].ConnectionString;
        }
        
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
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "execute getAllPersons";

            try
            {
                List<Person> persons = new List<Person>();
                command.Connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Person person = new Person
                    {
                        Id = int.Parse(reader[0].ToString()),
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        BirthDate = DateTime.Parse(reader[3].ToString()),
                        Age = int.Parse(reader[4].ToString())
                    };

                    persons.Add(person);
                }

                return persons;
            }
            finally
            {
                command.Connection.Close();
            }
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