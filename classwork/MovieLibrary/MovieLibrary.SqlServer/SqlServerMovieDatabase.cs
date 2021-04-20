using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MovieLibrary.SqlServer
{
    //ADO.NET (* represents database product name)
    //  System.Data.*Client - namespace for database product types
    //      *Connection - connection to database (DBConnection)
    //              Expensive to create so use connection pool, set when Open called
    //      *Command - command to do some work
    //          CommandText - the work to do
    //          Parameters - Optional
    //          Command Type - raw command?
    //          Ways to create: new, conn.CreateCommand()
    //          Ways to execute:
    //              ExecuteScalar - returns back the first value of the first row as an object
    //      *Parameter - parameter to a comman
    //          Ways to create: new, cmd
    //          SQL parameters must begin with @ but generally are not case sensitive, order does not matter

    /// <summary>Provides an implementation of <see cref="IMovie Database"/> using Sql Server. </summary>
    /// <remarks>
    /// Relies on ADO.NET for database access.
    /// </remarks>
    public class SqlServerMovieDatabase : MovieDatabase
    {
        public SqlServerMovieDatabase (string connectionString )
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
            throw new NotImplementedException();
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            using (var conn = OpenConnection())
            {

            };

            return Enumerable.Empty<Movie>();
        }

        protected override Movie GetCore ( int id )
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            throw new NotImplementedException();
        }

        private readonly string _connectionString;
    }
}
