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
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
                // first row
                new[]
                {
                    InlineKeyboardButton.WithCallbackData(text: "Зарегистрироваться", callbackData: "post"),
                },

            });
        public Seminar(string path, int id,int day)
        {
            PathPicture = path;
            Seminar_Id = id;
            Day = day;
        }
        public InlineKeyboardMarkup inline()
        {
            return inlineKeyboard;
        }
    }
}
