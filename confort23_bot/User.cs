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
        private int Id;
        private int ChatId { get; } = 0;
        public int? SeminarId1;
        public int? SeminarId2;

        private SqlParameter nameParam = new SqlParameter
        {
            ParameterName = "@chatId",
        };
        private string SeminarExperession = "select_seminar_by_id";
        SqlParameter parameter = new SqlParameter()
        {
            ParameterName = "@id"
        };
        private SqlParameter idSeminar = new SqlParameter
        {
            ParameterName = "@id_seminar",
        };
        //OUTPUT
        public User(int id)
        {
            nameParam.Value = id;
            using (SqlConnection connection = new SqlConnection(Messages.ConnectionString))
            {
                connection.Open();
                string user_find = $"SELECT * FROM Users WHERE ChatId = {id}";
                SqlCommand command = new SqlCommand(user_find, connection);
              //  command.CommandType = CommandType.StoredProcedure;
                // добавляем параметр
              //  command.Parameters.Add(nameParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("Id")))
                        {
                            Id = reader.GetInt32(0);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("ChatId")))
                        {
                            ChatId = reader.GetInt32(1);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("seminar1")))
                        {
                            SeminarId1 = reader.GetInt32(2);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("seminar2")))
                        {
                            SeminarId2 = reader.GetInt32(3);
                        }
                        //Console.WriteLine($"{Id} {ChatId} {SeminarId1} {SeminarId2}");
                    }
                }
                command.Parameters.Clear();
                reader.Close();
            }
            if(Id == 0)
            {
             using (SqlConnection connection2 =
             new SqlConnection(Messages.ConnectionString))
                {
                    connection2.Open();
                    ChatId = id;
                    // При обращении к созданнаму объекту все поля кроме ChatId равны null
                    string user_add = $"INSERT INTO Users(ChatId) Values({id})";
                    SqlCommand commandInsert = new SqlCommand(user_add, connection2);
                    //commandInsert.CommandType = CommandType.StoredProcedure;
                    // commandInsert.Parameters.Add(nameParam);
                    commandInsert.ExecuteNonQuery();
                    Console.WriteLine("User Add");
                }
            }
        }
        public string AddSeminar(int seminar_id)
        {
            idSeminar.Value = seminar_id;
            parameter.Value = Id;
            string descriptonSeminar = null;

            using (var conection = new SqlConnection(Messages.ConnectionString))
            {
                conection.Open();
                string select_day = @$"select day,descrip from Seminars
                                         where seminar_id = {seminar_id}";
                var commandSelect = new SqlCommand(select_day, conection);
                SqlDataReader reader = commandSelect.ExecuteReader();
                int day = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        day = reader.GetInt32(0);
                        if (!reader.IsDBNull(reader.GetOrdinal("descrip")))
                        {
                            descriptonSeminar = reader.GetString(1);
                        }

                    }
                }
                reader.Close();
               if (day == 1)
                {
                    //Add seminar 1
                    string add_seminar1 = @$"UPDATE Users
                                            SET seminar1 = {seminar_id}
                                            Where Id = {Id}";
                    var command = new SqlCommand(add_seminar1, conection);
                    
                    command.ExecuteNonQuery();
                    Console.WriteLine("add seminar1");
                }
                if (day == 2)
                {
                    //Add seminar 2
                    string add_seminar2 = @$"UPDATE Users
                                            SET seminar2 = {seminar_id}
                                            Where Id = {Id}";
                    var command = new SqlCommand(add_seminar2, conection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("add seminar2");
                }
            }
            return descriptonSeminar;
        }

    }
}
