using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace confort23_bot
{
    public class Seminars : Start
    {
        public List<string>? imagePaths;
        public Seminars() { }   
        public Seminars(string day)
        {
            //TODO: Serializtion from file
            if (day == Messages.Day1)
            {
                imagePaths = new List<string>()
                {
                   Path.Combine(Environment.CurrentDirectory, "B:\\conf23_bot\\confort23_bot\\confort23_bot\\seminars_day1\\seminar1.jpg"),
                   Path.Combine(Environment.CurrentDirectory, "B:\\conf23_bot\\confort23_bot\\confort23_bot\\seminars_day1\\seminar2.jpg")
                };
            }
            else
            {
                imagePaths = new List<string>()
                {
                  Path.Combine(Environment.CurrentDirectory, "B:\\conf23_bot\\confort23_bot\\confort23_bot\\seminars_day1\\seminar2.jpg"),
                  Path.Combine(Environment.CurrentDirectory, "B:\\conf23_bot\\confort23_bot\\confort23_bot\\seminars_day1\\seminar3.jpg")
               };
            }
        }


        public List<KeyboardButton> Days = new List<KeyboardButton>()
        {
            new KeyboardButton(Messages.Day1),
            new KeyboardButton(Messages.Day2),
            new KeyboardButton(Messages.GoBack)
        };
        
 
        public override ReplyKeyboardMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup(Days);
        }
        async public Task SendSeminarPiqture(Mydelegate Send,long chatID)
        {
            if (imagePaths != null)
            {
                foreach (var imagePaths in imagePaths)
                {
                    await Send(chatID, imagePaths);
                }
            }
        }

    }
}
