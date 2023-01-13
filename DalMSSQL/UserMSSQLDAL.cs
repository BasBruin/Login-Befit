using InterfaceLib.DTO_s;
using InterfaceLib.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace DalMSSQL
{
    public class UserMSSQLDAL : IUserContainer
    {
        private readonly string connString;
        SqlDataReader? reader;
        private readonly SqlConnection connection;

        /// <summary>
        /// Hier maak je een GebruikerDAL.
        /// </summary>
        /// <param name="cs">Hier geef je de connectiestring mee</param>
        public UserMSSQLDAL(string cs)
        {
            connString = cs;
            connection = new SqlConnection(connString);
        }

        public int? FindByUsernameAndPassword(string? username, string? password)
        {
            connection.Open();
            SqlCommand command;
            string sql = "SELECT * FROM Gymmember WHERE Username = @username";

            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@username", username);
            reader = command.ExecuteReader();

            

            if (reader.Read())
            {
                if (reader.GetString("Password") == password)
                {
                    int id = reader.GetInt32("Id");
                    connection.Close();
                    return id;
                }
                return null;
            }
            connection.Close();
            return null;
        }
    }
}