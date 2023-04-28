using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace confort23_bot
{
    public class Start
    {
 
        private List<KeyboardButton> Buttons = new List<KeyboardButton>() 
        {
           new KeyboardButton(Messages.ContactsMessage),
           new KeyboardButton(Messages.QuestionMessage),
           new KeyboardButton(Messages.RegistrationSeminar),
           new KeyboardButton(Messages.Timetable),
           new KeyboardButton(Messages.Chat),
           new KeyboardButton(Messages.ToGuests)
        }; 
        public virtual ReplyKeyboardMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup(Buttons);
        }
    }
}
