using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confort23_bot
{
    public class User
    {
        private long Id { get; } = 0;
        public Seminar? RegisteredDay1;
        public Seminar? RegisteredDay2;

        public User(long id)
        {
            using (SqlConnection connection =
            new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=B:\\conf23_bot\\confort23_bot\\confort23_bot\\CONFBOTDB.mdf;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT Id FROM Users Where ChatId={id}", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    Console.WriteLine("User found");
                    Id = (long)reader.GetValue(0);
                }
                reader.Close();

            }
            if(Id == 0)
            {
             using (SqlConnection connection =
             new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=B:\\conf23_bot\\confort23_bot\\confort23_bot\\CONFBOTDB.mdf;Integrated Security=True"))
                {
                    connection.Open();
                    Id = id;
                    SqlCommand commandInsert = new SqlCommand($"INSERT INTO Users(Id,ChatID) Values(2,{id})", connection);
                    commandInsert.ExecuteNonQuery();
                    Console.WriteLine("User Add");
                }
            }
        }
         
    }
}
