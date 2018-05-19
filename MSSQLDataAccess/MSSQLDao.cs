using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.getAllPersons", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection.Open();

                    command.Parameters.AddWithValue("@first_name", person.FirstName);
                    command.Parameters.AddWithValue("@last_name", person.LastName);
                    command.Parameters.AddWithValue("@birth_date", person.BirthDate);
                    command.Parameters.AddWithValue("@age", person.Age);
                    
                    var id = command.Parameters.Add("@id", SqlDbType.Int);
                    id.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

//                    return id.Value;
                }
            }

            return true;
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

        public void AddAddressToPerson(Person person, Address address)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.getAllPersons", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    List<Person> persons = new List<Person>();
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
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
                    }

                    return persons;
                }
            }
        }

        public IEnumerable<Medal> GetAllMedals()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.getAllMedals", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    List<Medal> medals = new List<Medal>();
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Medal medal = new Medal
                            {
                                Id = int.Parse(reader[0].ToString()),
                                Material = new Material
                                {
                                    Id = int.Parse(reader[1].ToString()),
                                    Name = reader[2].ToString()
                                }
                            };

                            medals.Add(medal);
                        }
                    }

                    return medals;
                }
            }
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.getAllAddresses", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    List<Address> addresses = new List<Address>();
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Address address = new Address
                            {
                                Id = int.Parse(reader[0].ToString()),
                                City = reader[1].ToString(),
                                Street = reader[2].ToString(),
                                HouseNumber = reader[3].ToString()
                            };

                            addresses.Add(address);
                        }
                    }

                    return addresses;
                }
            }
        }

        public IEnumerable<Material> GetAllMaterials()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.getAllMaterials", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    List<Material> materials = new List<Material>();
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Material material = new Material
                            {
                                Id = int.Parse(reader[0].ToString()),
                                Name = reader[1].ToString()
                            };

                            materials.Add(material);
                        }
                    }

                    return materials;
                }
            }
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