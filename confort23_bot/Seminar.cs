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
        public int Seminar_Id { get; set; }
        public string PathPicture;
        public int Day { get; set; }
        public string Description;
        public string NameButton = "Зарегистрироваться";
        InlineKeyboardMarkup inlineKeyboard;
        public Seminar(string path, int id, int day)
        {
            PathPicture = path;
            Seminar_Id = id;
            Day = day;
            inlineKeyboard = new(new[]
            {

            new[]
                {
                    InlineKeyboardButton.WithCallbackData(text:"Зарегистрироваться на семинар", callbackData:Convert.ToString(id)),
                },
           });
        }
        public InlineKeyboardMarkup inline()
        {
            return inlineKeyboard;
        }
    }
}
