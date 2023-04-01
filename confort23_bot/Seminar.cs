using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace confort23_bot
{
    public class Seminar
    {
        private string connectionString = "Server=.\\SQLEXPRESS;Database=Conffort_botDB;Trusted_Connection=True;";
        private string sqlExpression = "SELECT * FROM Users";
        public string PathPicture;
        public string Description;
        public string NameButton;
        private KeyboardButton button;
        public Seminar()
        {
    
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        PathPicture = (string)reader.GetValue(1);
                        Description = (string)reader.GetValue(2);
                    }
                }

                reader.Close();
            }
        }
        public ReplyKeyboardMarkup GetSemenarButton()
        {
            return new ReplyKeyboardMarkup(button);
        }
    }
}
