using Entities;

using System.Data.SqlClient;

namespace DataAccess
{
    public class Repository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NotesDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Repository()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                connection.Close();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Could not establish a connection to the database", e);
            }
        }

        public List<Note> GetAllNotes()
        {
            List<Note> notes = new List<Note>();
            string sql = "SELECT * FROM Notes";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new(sql, connection);
            connection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                Note note = new(
                    (int)dataReader["NoteId"],
                    (DateTime)dataReader["Created"],
                    (string)dataReader["Title"],
                    (string)dataReader["Text"]
                    );
                notes.Add(note);
            }
            connection.Close();
            return notes;
        }

        public void SaveNew(Note note)
        {

        }
    }
}