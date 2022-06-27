using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using car_care.Models;

namespace car_care._Repositories
{
    public class PRepository : BaseRepository, IPRepository
    {
        //Constructor
        public PRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        //Methods
        public void Add(PModel PModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Pet values (@name, @type, @colour)";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = PModel.Name;
                command.Parameters.Add("@type", SqlDbType.NVarChar).Value = PModel.Type;
                command.Parameters.Add("@colour", SqlDbType.NVarChar).Value = PModel.Colour;
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Pet where Pet_Id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }
        public void Edit(PModel PModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Pet 
                                        set Pet_Name=@name,Pet_Type= @type,Pet_Colour= @colour 
                                        where Pet_Id=@id";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = PModel.Name;
                command.Parameters.Add("@type", SqlDbType.NVarChar).Value = PModel.Type;
                command.Parameters.Add("@colour", SqlDbType.NVarChar).Value = PModel.Colour;
                command.Parameters.Add("@id", SqlDbType.Int).Value = PModel.Id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<PModel> GetAll()
        {
            var petList = new List<PModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select *from Pet order by Pet_Id desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var PModel = new PModel();
                        PModel.Id = (int)reader[0];
                        PModel.Name = reader[1].ToString();
                        PModel.Type = reader[2].ToString();
                        PModel.Colour = reader[3].ToString();
                        petList.Add(PModel);
                    }
                }
            }
            return petList;
        }

        public IEnumerable<PModel> GetByValue(string value)
        {
            var petList = new List<PModel>();
            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string petName = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select *from Pet
                                        where Pet_Id=@id or Pet_Name like @name+'%' 
                                        order by Pet_Id desc";
                command.Parameters.Add("@id", SqlDbType.Int).Value = petId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = petName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var PModel = new PModel();
                        PModel.Id = (int)reader[0];
                        PModel.Name = reader[1].ToString();
                        PModel.Type = reader[2].ToString();
                        PModel.Colour = reader[3].ToString();
                        petList.Add(PModel);
                    }
                }
            }
            return petList;
        }
    }
}