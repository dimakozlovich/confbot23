using System;
using System.Collections.Generic;
using System.Data;
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
        private string sqlExpressionFind = "findUser";
        private string sqlExpressionAdd = "addUser";
        private SqlParameter nameParam = new SqlParameter
        {
            ParameterName = "@chatId",
        };

        public User(long id)
        {
            nameParam.Value = id;
            using (SqlConnection connection =
            new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=B:\\conf23_bot\\confort23_bot\\confort23_bot\\CONFBOTDB.mdf;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpressionFind, connection);
                command.CommandType = CommandType.StoredProcedure;
                // добавляем параметр
                command.Parameters.Add(nameParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    Console.WriteLine("User found");
                    //Id = (long)reader["ChatId"];
                    Id = id;
                }
                command.Parameters.Clear();
                reader.Close();
            }
            if(Id == 0)
            {
             using (SqlConnection connection =
             new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=B:\\conf23_bot\\confort23_bot\\confort23_bot\\CONFBOTDB.mdf;Integrated Security=True"))
                {
                    connection.Open();
                    Id = id;
                    SqlCommand commandInsert = new SqlCommand(sqlExpressionAdd, connection);
                    commandInsert.CommandType = CommandType.StoredProcedure;
                    commandInsert.Parameters.Add(nameParam);
                    commandInsert.ExecuteNonQuery();
                    Console.WriteLine("User Add");
                    commandInsert.Parameters.Clear();
                }
            }
        }
         
    }
}
