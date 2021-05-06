/*
 * Character Creator - Lab 5
 * ITSE 1430
 * Spring 2021
 * Matthew Smith
 * May 5, 2021
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CharacterCreator.SqlServer
{
    /// <summary> Provides an implementation of <see cref="ICharacterRoster"/> using SQL Server. </summary>
    /// <remarks> Relies on ADO.NET for database access. </remarks>
    public class SqlServerCharacterRoster : CharacterRoster
    {
        public SqlServerCharacterRoster (string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override Character AddCore ( Character character )
        {

            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("AddCharacter", conn) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@name", character.Name));
                cmd.Parameters.AddWithValue("@profession", character.Profession);
                cmd.Parameters.AddWithValue("@race", character.Race);
                cmd.Parameters.AddWithValue("@description", character.Biography);
                cmd.Parameters.AddWithValue("@attribute1", character.StrengthAttribute);
                cmd.Parameters.AddWithValue("@attribute2", character.IntelligenceAttribute);
                cmd.Parameters.AddWithValue("@attribute3", character.AgilityAttribute);
                cmd.Parameters.AddWithValue("@attribute4", character.ConstitutionAttribute);
                cmd.Parameters.AddWithValue("@attribute5", character.CharismaAttribute);

                //Getting result back
                object result = cmd.ExecuteScalar();

                character.Id = Convert.ToInt32(result);
            };

            return character;
        }

        private SqlConnection OpenConnection ()
        {
            //Connect to db using SqlConnection
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;            
        }

        protected override void DeleteCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("DeleteCharacter", conn) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", id);

                //No result expected
                cmd.ExecuteNonQuery();
            };
        }

        protected override IEnumerable<Character> GetAllCore ()
        {
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetAllCharacters";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //New to create a dataset and data adapter
                var ds = new DataSet();
                var da = new SqlDataAdapter() {
                    SelectCommand = cmd   
                };

                //Fill the dataset
                da.Fill(ds);

                //Get first table, if any, and then enumerate the rows
                var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
                if (table != null)
                {
                    foreach (var row in table.Rows.OfType<DataRow>())
                    {
                        yield return new Character() {
                            Id = (int)row[0],
                            Name = row.Field<string>("Name"),
                            Profession = row.Field<string>("Profession"),
                            Race = row.Field<string>("Race"),
                            Biography = row.Field<string>("Description"),
                            StrengthAttribute = row.Field<int>("Attribute1"),
                            IntelligenceAttribute = row.Field<int>("Attribute2"),
                            AgilityAttribute = row.Field<int>("Attribute3"),
                            ConstitutionAttribute = row.Field<int>("Attribute4"),
                            CharismaAttribute = row.Field<int>("Attribute5"),
                        };
                    };
                };
            };
        }

        protected override Character FindCharacterByName ( string name )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("FindCharacterByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Character() {
                            Id = (int)reader[0],
                            Name = reader.GetString("Name"),
                            Profession = reader.GetString("Profession"),
                            Race = reader.GetString("Race"),
                            Biography = reader.IsDBNull("Description") ? null : reader.GetString("Description"),
                            StrengthAttribute = reader.GetFieldValue<int>("Attribute1"),
                            IntelligenceAttribute = reader.GetFieldValue<int>("Attribute2"),
                            AgilityAttribute = reader.GetFieldValue<int>("Attribute3"),
                            ConstitutionAttribute = reader.GetFieldValue<int>("Attribute4"),
                            CharismaAttribute = reader.GetFieldValue<int>("Attribute5"),
                        };
                    };
                };
            };

            return null;
        }

        protected override Character GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetCharacter", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Character() {
                            Id = (int)reader[0],
                            Name = reader.GetString("Name"),
                            Profession = reader.GetString("Profession"),
                            Race = reader.GetString("Race"),
                            Biography = reader.IsDBNull("Description") ? null : reader.GetString("Description"),
                            StrengthAttribute = reader.GetFieldValue<int>("Attribute1"),
                            IntelligenceAttribute = reader.GetFieldValue<int>("Attribute2"),
                            AgilityAttribute = reader.GetFieldValue<int>("Attribute3"),
                            ConstitutionAttribute = reader.GetFieldValue<int>("Attribute4"),
                            CharismaAttribute = reader.GetFieldValue<int>("Attribute5"),
                        };
                    };
                };
            };

            return null;
        }

        protected override void UpdateCore ( int id, Character character )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateCharacter", conn) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                //Always use parameterized queries
                cmd.Parameters.Add(new SqlParameter("@name", character.Name));
                cmd.Parameters.AddWithValue("@profession", character.Profession);
                cmd.Parameters.AddWithValue("@race", character.Race);
                cmd.Parameters.AddWithValue("@description", character.Biography);
                cmd.Parameters.AddWithValue("@attribute1", character.StrengthAttribute);
                cmd.Parameters.AddWithValue("@attribute2", character.IntelligenceAttribute);
                cmd.Parameters.AddWithValue("@attribute3", character.AgilityAttribute);
                cmd.Parameters.AddWithValue("@attribute4", character.ConstitutionAttribute);
                cmd.Parameters.AddWithValue("@attribute5", character.CharismaAttribute);
                cmd.Parameters.AddWithValue("@id", id);

                //No result
                cmd.ExecuteNonQuery();
            };
        }
        private readonly string _connectionString;
    }
}
