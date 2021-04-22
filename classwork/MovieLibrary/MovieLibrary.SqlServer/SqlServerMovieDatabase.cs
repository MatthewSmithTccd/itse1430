using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MovieLibrary.SqlServer
{
    //ADO.NET (* represents database product name)
    //  System.Data.*Client - namespace for database product types
    //   *Connection - connection to database (DbConnection)
    //       Expensive to create so use connection pool, set when Open called
    //   *Command - command to do some work
    //       CommandText - the work to do
    //       Parameters - Optional
    //       CommandType - raw command?
    //       Ways to create: new, conn.CreateCommand()
    //       Ways to execute:  
    //           ExecuteNonQuery - ignores return set (e.g. update, delete)
    //           ExecuteScalar - returns back the first value of the first row as an object (e.g. INSERT)
    //           ExecuteReader - returns data reader to stream data
    //   *Parameter - parameter to a command
    //       Ways to create: new, cmd
    //       SQL parameters must begin with @ but generally are not case sensitive, order does not matter
    //   Reading data (or resultsets)
    //       Dataset (buffered) - in memory representation of a database table(s)
    //           Table(s) -> Column(s) and Row(s)
    //           Foreach on row
    //              row[#], row[string] -> object, does not handle DBNull
    //              row.Field<T>(#), row.Field<T>(string) -> T, handles DBNull
    //              DBNull.Value used for NULL in the DB
    //           Useful for: data manipulation, discovery, simple data storage
    //       Data reader (streamed)
    //           Call cmd.ExecuteReader to get data reader that must be disposed
    //           while (reader.Read())
    //             reader[#], reader[string] -> object, does not handle DBNull
    //             reader.Get{type}(#), reader.Get{type}(string) -> type
    //             reader.GetFieldValue<T>(#), reader.GetFieldValue<T>(string) -> T
    //           Fastest way to read, efficient in memory, are not discoverable and do not include metadata
    //       Columns may be accessed using
    //           Zero-based ordinal - position dependent, harder to read, faster
    //           Name - position agnostic, easier to read, slightly slower (recommended)
    //   Dataset vs Data Reader
    //      Use a data reader
    //      Unless
    //         Working with unknown data (discoverability)
    //         Modify data (without business objects)
    //         No need for business types and/or too many business types
    //         Small # of rows (< 100s)
    //         Speed is not important (does this really ever happen??)
    //         Disconnected data (offline mode)

    /// <summary>Provides an implementation of <see cref="IMovieDatabase"/> using SQL Server.</summary>
    /// <remarks>
    /// Relies on ADO.NET for database access.
    /// </remarks>
    public class SqlServerMovieDatabase : MovieDatabase
    {
        public SqlServerMovieDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }

        protected override Movie AddCore ( Movie movie )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("AddMovie", conn) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                //Always use parameterized queries
                cmd.Parameters.Add(new SqlParameter("@name", movie.Title));
                cmd.Parameters.AddWithValue("@rating", movie.Rating);
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                //Getting a result back
                object result = cmd.ExecuteScalar();

                movie.Id = Convert.ToInt32(result);
            };

            return movie;
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
                var cmd = new SqlCommand("DeleteMovie", conn) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                //Always use parameterized queries
                cmd.Parameters.AddWithValue("@id", id);

                //No result expected
                cmd.ExecuteNonQuery();
            };
        }

        protected override Movie FindByTitle ( string title )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("FindByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", title);

                //Equivalent to a Stream/BinaryReader - must be disposed
                using (var reader = cmd.ExecuteReader())
                {
                    //Reads next row, if any
                    while (reader.Read())
                    {
                        return new Movie() {
                            Id = (int)reader[0],
                            Title = (string)reader["Name"],
                            Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                            Rating = reader.GetString("Rating"),                //Preferred
                            ReleaseYear = reader.GetFieldValue<int>(4),
                            RunLength = reader.GetFieldValue<int>("RunLength"),
                            IsClassic = reader.GetFieldValue<bool>("IsClassic") //Preferred
                        };
                    };
                };
            };

            return null;
        }

        protected override Movie GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                //Equivalent to a Stream/BinaryReader - must be disposed
                using (var reader = cmd.ExecuteReader())
                {
                    //Reads next row, if any
                    while (reader.Read())
                    {
                        return new Movie() {
                            Id = (int)reader[0],
                            Title = (string)reader["Name"],
                            Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                            Rating = reader.GetString("Rating"),                //Preferred
                            ReleaseYear = reader.GetFieldValue<int>(4),
                            RunLength = reader.GetFieldValue<int>("RunLength"),
                            IsClassic = reader.GetFieldValue<bool>("IsClassic") //Preferred
                        };
                    };
                };
            };

            return null;
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetMovies";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //New to create a dataset and data adapter
                var ds = new DataSet();
                var da = new SqlDataAdapter() {
                    SelectCommand = cmd   //Set to command that retrieves the data
                    //, InsertCommand =,
                    //DeleteCommand = ,
                    //UpdateCommand = ,
                };

                //Fill the dataset
                da.Fill(ds);

                //Get first table, if any, and then enumerate the rows
                var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
                if (table != null)
                {
                    foreach (var row in table.Rows.OfType<DataRow>())
                    {
                        //DBNull.Value  //DB null

                        yield return new Movie() {
                            Id = (int)row[0],
                            Title = (string)row["Name"],
                            //Description = row.Field<string>(2),  
                            Description = row.IsNull(2) ? null : (string)row[2],
                            Rating = row.Field<string>("Rating"), //Preferred
                            RunLength = row.Field<int>("RunLength"),
                            ReleaseYear = row.Field<int>("ReleaseYear"),
                            IsClassic = row.Field<bool>("IsClassic")
                        };
                    };
                };
            };
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateMovie", conn) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                //Always use parameterized queries
                cmd.Parameters.Add(new SqlParameter("@name", movie.Title));
                cmd.Parameters.AddWithValue("@rating", movie.Rating);
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);
                cmd.Parameters.AddWithValue("@id", id);

                //No result
                cmd.ExecuteNonQuery();
            };
        }

        private readonly string _connectionString;
    }
}
