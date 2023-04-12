using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace confort23_bot
{
    public class RegistrationSeminars : Seminars
    {
        List<Seminar> _seminars;
        private string sqlExpressionSelect = "select_seminars";
        private SqlParameter nameParam = new SqlParameter
        {
            ParameterName = "@day",
        };

        public RegistrationSeminars() { _seminars = new List<Seminar>(); }
        public RegistrationSeminars(string day) 
        { 
            _seminars = new List<Seminar>();
          if(day == Messages.Day1)
            {
                nameParam.Value = 1;
            }
          else
            {
                nameParam.Value = 2;
            }
          using(var conection = new SqlConnection(
          "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=B:\\conf23_bot\\confort23_bot\\confort23_bot\\CONFBOTDB.mdf;Integrated Security=True"))
            {
                conection.Open();
                var command = new SqlCommand(sqlExpressionSelect, conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(nameParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("seminar found");
                        var seminar = new Seminar(
                            (string)reader["path_picture"],
                            (int)reader["seminar_id"],
                            (int)reader["day"]
                            );
                        _seminars.Add(seminar);
                    }
                }
                command.Parameters.Clear();
                reader.Close();
            }

        }
        async public override Task SendSeminarPiqture(Mydelegate Send, long chatID)
        {
          if(_seminars != null)
            {
                foreach(var seminar in _seminars)
                {
                    await Send(chatID, seminar.PathPicture,seminar.inline());
                }
            }
        }

    }
}
